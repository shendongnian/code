    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using Exchange = Microsoft.Exchange.WebServices.Data;
    static internal class Main
    {
      public static void Main()
      {
        Exchange.ExchangeService oService = default(Exchange.ExchangeService);
        Dictionary<string, User> oUsers = default(Dictionary<string, User>);
        oUsers = new Dictionary<string, User>();
        oUsers.Add("User1", new User("write.to.me1@my.address.com", "Some-Fancy-Password1"));
        oUsers.Add("User2", new User("write.to.me2@my.address.com", "Some-Fancy-Password2"));
        oUsers.ToList.ForEach((KeyValuePair<string, User> Credential) => { File.Delete(LOG_FILE_PATH.ToFormat(Credential.Key)); });
        oUsers.ToList.ForEach((KeyValuePair<string, User> Credential) =>
        {
          LogFileName = Credential.Key;
          Console.WriteLine("Getting message counts for mailbox [{0}]...", LogFileName);
          Console.WriteLine();
          oService = Service.ConnectToService(Credential.Value);
          GetAllFolders(oService, LOG_FILE_PATH.ToFormat(Credential.Key));
          Console.Clear();
        });
        Console.WriteLine();
        Console.Write("Press any key to exit...");
        Console.ReadKey();
      }
      private static void GetAllFolders(Exchange.ExchangeService Service, string LogFilePath)
      {
        Exchange.ExtendedPropertyDefinition oIsHidden = default(Exchange.ExtendedPropertyDefinition);
        List<Exchange.Folder> oFolders = default(List<Exchange.Folder>);
        Exchange.FindFoldersResults oResults = default(Exchange.FindFoldersResults);
        bool lHasMore = false;
        Exchange.Folder oChild = default(Exchange.Folder);
        Exchange.FolderView oView = default(Exchange.FolderView);
        short nPageSize = 0;
        short nOffSet = 0;
        List<string> oPaths = default(List<string>);
        List<string> oPath = default(List<string>);
        oIsHidden = new Exchange.ExtendedPropertyDefinition(0x10f4, Exchange.MapiPropertyType.Boolean);
        nPageSize = 1000;
        oFolders = new List<Exchange.Folder>();
        lHasMore = true;
        nOffSet = 0;
        while (lHasMore) {
          oView = new Exchange.FolderView(nPageSize, nOffSet, Exchange.OffsetBasePoint.Beginning);
          oView.PropertySet = new Exchange.PropertySet(Exchange.BasePropertySet.IdOnly);
          oView.PropertySet.Add(oIsHidden);
          oView.PropertySet.Add(Exchange.FolderSchema.ParentFolderId);
          oView.PropertySet.Add(Exchange.FolderSchema.DisplayName);
          oView.PropertySet.Add(Exchange.FolderSchema.FolderClass);
          oView.PropertySet.Add(Exchange.FolderSchema.TotalCount);
          oView.Traversal = Exchange.FolderTraversal.Deep;
          oResults = Service.FindFolders(Exchange.WellKnownFolderName.MsgFolderRoot, oView);
          oFolders.AddRange(oResults.Folders);
          lHasMore = oResults.MoreAvailable;
          if (lHasMore) {
            nOffSet += nPageSize;
          }
        }
        oFolders.RemoveAll(Folder => Folder.ExtendedProperties(0).Value == true);
        oFolders.RemoveAll(Folder => Folder.FolderClass != "IPF.Note");
        oPaths = new List<string>();
        oFolders.ForEach(Folder =>
        {
          oChild = Folder;
          oPath = new List<string>();
          do {
            oPath.Add(oChild.DisplayName);
            oChild = oFolders.SingleOrDefault(Parent => Parent.Id.UniqueId == oChild.ParentFolderId.UniqueId);
          } while (oChild != null);
          oPath.Reverse();
          oPaths.Add("{0}{1}{2}".ToFormat(Strings.Join(oPath.ToArray, DELIMITER), Constants.vbTab, Folder.TotalCount));
        });
        oPaths.RemoveAll(Path => Path.StartsWith("Sync Issues"));
        File.WriteAllText(LogFilePath, Strings.Join(oPaths.ToArray, Constants.vbCrLf));
      }
      private static string LogFileName;
      private const string LOG_FILE_PATH = "D:\\Emails\\Remote{0}.txt";
      private const string DELIMITER = "\\";
    }
    internal class Service
    {
      public static Exchange.ExchangeService ConnectToService(User User)
      {
        return Service.ConnectToService(User, null);
      }
      public static Exchange.ExchangeService ConnectToService(User User, Exchange.ITraceListener Listener)
      {
        Exchange.ExchangeService oService = default(Exchange.ExchangeService);
        oService = new Exchange.ExchangeService(Exchange.ExchangeVersion.Exchange2013_SP1);
        oService.Credentials = new NetworkCredential(User.EmailAddress, User.Password);
        oService.AutodiscoverUrl(User.EmailAddress, RedirectionUrlValidationCallback);
        if (Listener != null) {
          oService.TraceListener = Listener;
          oService.TraceEnabled = true;
          oService.TraceFlags = Exchange.TraceFlags.All;
        }
        return oService;
      }
      private static bool RedirectionUrlValidationCallback(string RedirectionUrl)
      {
        var _with1 = new Uri(RedirectionUrl);
        return _with1.Scheme.ToLower == "https";
      }
    }
    internal class User
    {
      public User(string EmailAddress)
      {
        _EmailAddress = EmailAddress;
        _Password = new SecureString();
      }
      public User(string EmailAddress, string Password)
      {
        _EmailAddress = EmailAddress;
        _Password = new SecureString();
        Password.ToList.ForEach((char Chr) => { this.Password.AppendChar(Chr); });
        Password.MakeReadOnly();
      }
      public static User GetUser()
      {
        User functionReturnValue = null;
        string sEmailAddress = null;
        ConsoleKeyInfo oUserInput = default(ConsoleKeyInfo);
        Console.Write("Enter email address: ");
        sEmailAddress = Console.ReadLine;
        Console.Write("Enter password: ");
        functionReturnValue = new User(sEmailAddress);
        while (true) {
          oUserInput = Console.ReadKey(true);
          if (oUserInput.Key == ConsoleKey.Enter) {
            break; // TODO: might not be correct. Was : Exit While
          } else if (oUserInput.Key == ConsoleKey.Escape) {
            functionReturnValue.Password.Clear();
          } else if (oUserInput.Key == ConsoleKey.Backspace) {
            if (functionReturnValue.Password.Length != 0) {
              functionReturnValue.Password.RemoveAt(functionReturnValue.Password.Length - 1);
            }
          } else {
            functionReturnValue.Password.AppendChar(oUserInput.KeyChar);
            Console.Write("*");
          }
        }
        if (functionReturnValue.Password.Length == 0) {
          functionReturnValue = null;
        } else {
          functionReturnValue.Password.MakeReadOnly();
          Console.WriteLine();
        }
        return functionReturnValue;
      }
      public string EmailAddress { get; }
      public SecureString Password { get; }
    }
    internal class TraceListener : Exchange.ITraceListener
    {
      public void Trace(string TraceType, string TraceMessage)
      {
        File.AppendAllText("{0}.txt".ToFormat(Path.Combine("D:\\Emails\\TraceOutput", Guid.NewGuid.ToString("D"))), TraceMessage);
      }
    }
    //=======================================================
    //Service provided by Telerik (www.telerik.com)
    //Conversion powered by NRefactory.
    //Twitter: @telerik
    //Facebook: facebook.com/telerik
    //=======================================================
