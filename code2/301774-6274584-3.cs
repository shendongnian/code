        public class FriendList
        {
          public List<Friend> friends;
          public FriendList()
          {
            friends= new List<Friend>();
          }
        }
    public class Friend
    {  
      public string UID {get;set;} 
      public string Provider {get;set;}  
      public string PhotoUrl {get;set;}   
      public string ProfileUrl {get;set;}
    }
    
    Public class ParseFriends
    {
      FriendList p = new FriendList();
      public ReadFriends()
      {
        DirectoryInfo dir = new DirectoryInfo("../path to your xml file");
        FileInfo[] files = dir.GetFiles("*.*"); // read all xml file from a folder
        XmlDocument doc = new XmlDocument();
    
        foreach (FileInfo f in files)
                {
                    Friend e = new Friend();
                    doc.Load(f.FullName);
                    e.UID = doc.GetElementsByTagName("UID")[0].InnerText;
                    e.Provider = doc.GetElementsByTagName("Provider")[0].InnerText;
                    e.PhotoUrl = doc.GetElementsByTagName("PhotoUrl")[0].InnerText;
                    e.ProfileUrl = doc.GetElementsByTagName("ProfileUrl")[0].InnerText;
                    p.empDetails.Add(e);
                }
                return p;
      }
    }
