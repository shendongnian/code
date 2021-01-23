        public class FriendList
        {
          public List<Friend> friends;
          public FriendList()
          {
            friends= new List<Friend>();
          }
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
                    e.empId = doc.GetElementsByTagName("UID")[0].InnerText;
                    e.empName = doc.GetElementsByTagName("Provider")[0].InnerText;
                    e.empSeatNo = doc.GetElementsByTagName("PhotoUrl")[0].InnerText;
                    e.projGroup = doc.GetElementsByTagName("ProfileUrl")[0].InnerText;
                    p.empDetails.Add(e);
                }
                return p;
      }
    }
