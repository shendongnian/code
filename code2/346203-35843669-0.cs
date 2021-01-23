    Imports Exchange = Microsoft.Exchange.WebServices.Data
    Friend Module Main
      Public Sub Main()
        Dim oService As Exchange.ExchangeService
        Dim oUsers As Dictionary(Of String, User)
        oUsers = New Dictionary(Of String, User)
        oUsers.Add("User1", New User("write.to.me1@my.address.com", "Some-Fancy-Password1"))
        oUsers.Add("User2", New User("write.to.me2@my.address.com", "Some-Fancy-Password2"))
        oUsers.ToList.ForEach(Sub(Credential As KeyValuePair(Of String, User))
                                File.Delete(LOG_FILE_PATH.ToFormat(Credential.Key))
                              End Sub)
        oUsers.ToList.ForEach(Sub(Credential As KeyValuePair(Of String, User))
                                LogFileName = Credential.Key
                                Console.WriteLine("Getting message counts for mailbox [{0}]...", LogFileName)
                                Console.WriteLine()
                                oService = Service.ConnectToService(Credential.Value)
                                GetAllFolders(oService, LOG_FILE_PATH.ToFormat(Credential.Key))
                                Console.Clear()
                              End Sub)
        Console.WriteLine()
        Console.Write("Press any key to exit...")
        Console.ReadKey()
      End Sub
      Private Sub GetAllFolders(Service As Exchange.ExchangeService, LogFilePath As String)
        Dim oIsHidden As Exchange.ExtendedPropertyDefinition
        Dim oFolders As List(Of Exchange.Folder)
        Dim oResults As Exchange.FindFoldersResults
        Dim lHasMore As Boolean
        Dim oChild As Exchange.Folder
        Dim oView As Exchange.FolderView
        Dim _
          nPageSize,
          nOffSet As Short
        Dim _
          oPaths,
          oPath As List(Of String)
        oIsHidden = New Exchange.ExtendedPropertyDefinition(&H10F4, Exchange.MapiPropertyType.Boolean)
        nPageSize = 1000
        oFolders = New List(Of Exchange.Folder)
        lHasMore = True
        nOffSet = 0
        Do While lHasMore
          oView = New Exchange.FolderView(nPageSize, nOffSet, Exchange.OffsetBasePoint.Beginning)
          oView.PropertySet = New Exchange.PropertySet(Exchange.BasePropertySet.IdOnly)
          oView.PropertySet.Add(oIsHidden)
          oView.PropertySet.Add(Exchange.FolderSchema.ParentFolderId)
          oView.PropertySet.Add(Exchange.FolderSchema.DisplayName)
          oView.PropertySet.Add(Exchange.FolderSchema.FolderClass)
          oView.PropertySet.Add(Exchange.FolderSchema.TotalCount)
          oView.Traversal = Exchange.FolderTraversal.Deep
          oResults = Service.FindFolders(Exchange.WellKnownFolderName.MsgFolderRoot, oView)
          oFolders.AddRange(oResults.Folders)
          lHasMore = oResults.MoreAvailable
          If lHasMore Then
            nOffSet += nPageSize
          End If
        Loop
        oFolders.RemoveAll(Function(Folder) Folder.ExtendedProperties(0).Value = True)
        oFolders.RemoveAll(Function(Folder) Folder.FolderClass <> "IPF.Note")
        oPaths = New List(Of String)
        oFolders.ForEach(Sub(Folder)
                           oChild = Folder
                           oPath = New List(Of String)
                           Do
                             oPath.Add(oChild.DisplayName)
                             oChild = oFolders.SingleOrDefault(Function(Parent) Parent.Id.UniqueId = oChild.ParentFolderId.UniqueId)
                           Loop While oChild IsNot Nothing
                           oPath.Reverse()
                           oPaths.Add("{0}{1}{2}".ToFormat(Join(oPath.ToArray, DELIMITER), vbTab, Folder.TotalCount))
                         End Sub)
        oPaths.RemoveAll(Function(Path) Path.StartsWith("Sync Issues"))
        File.WriteAllText(LogFilePath, Join(oPaths.ToArray, vbCrLf))
      End Sub
      Private LogFileName As String
      Private Const LOG_FILE_PATH As String = "D:\Emails\Remote{0}.txt"
      Private Const DELIMITER As String = "\"
    End Module
    Friend Class Service
      Public Shared Function ConnectToService(User As User) As Exchange.ExchangeService
        Return Service.ConnectToService(User, Nothing)
      End Function
      Public Shared Function ConnectToService(User As User, Listener As Exchange.ITraceListener) As Exchange.ExchangeService
        Dim oService As Exchange.ExchangeService
        oService = New Exchange.ExchangeService(Exchange.ExchangeVersion.Exchange2013_SP1)
        oService.Credentials = New NetworkCredential(User.EmailAddress, User.Password)
        oService.AutodiscoverUrl(User.EmailAddress, AddressOf RedirectionUrlValidationCallback)
        If Listener IsNot Nothing Then
          oService.TraceListener = Listener
          oService.TraceEnabled = True
          oService.TraceFlags = Exchange.TraceFlags.All
        End If
        Return oService
      End Function
      Private Shared Function RedirectionUrlValidationCallback(RedirectionUrl As String) As Boolean
        With New Uri(RedirectionUrl)
          Return .Scheme.ToLower = "https"
        End With
      End Function
    End Class
    Friend Class User
      Public Sub New(EmailAddress As String)
        _EmailAddress = EmailAddress
        _Password = New SecureString
      End Sub
      Public Sub New(EmailAddress As String, Password As String)
        _EmailAddress = EmailAddress
        _Password = New SecureString
        Password.ToList.ForEach(Sub(Chr As Char)
                                  Me.Password.AppendChar(Chr)
                                End Sub)
        Password.MakeReadOnly()
      End Sub
      Public Shared Function GetUser() As User
        Dim sEmailAddress As String
        Dim oUserInput As ConsoleKeyInfo
        Console.Write("Enter email address: ")
        sEmailAddress = Console.ReadLine
        Console.Write("Enter password: ")
        GetUser = New User(sEmailAddress)
        While True
          oUserInput = Console.ReadKey(True)
          If oUserInput.Key = ConsoleKey.Enter Then
            Exit While
          ElseIf oUserInput.Key = ConsoleKey.Escape Then
            GetUser.Password.Clear()
          ElseIf oUserInput.Key = ConsoleKey.Backspace Then
            If GetUser.Password.Length <> 0 Then
              GetUser.Password.RemoveAt(GetUser.Password.Length - 1)
            End If
          Else
            GetUser.Password.AppendChar(oUserInput.KeyChar)
            Console.Write("*")
          End If
        End While
        If GetUser.Password.Length = 0 Then
          GetUser = Nothing
        Else
          GetUser.Password.MakeReadOnly()
          Console.WriteLine()
        End If
      End Function
      Public ReadOnly Property EmailAddress As String
      Public ReadOnly Property Password As SecureString
    End Class
    Friend Class TraceListener
      Implements Exchange.ITraceListener
      Public Sub Trace(TraceType As String, TraceMessage As String) Implements Exchange.ITraceListener.Trace
        File.AppendAllText("{0}.txt".ToFormat(Path.Combine("D:\Emails\TraceOutput", Guid.NewGuid.ToString("D"))), TraceMessage)
      End Sub
    End Class
