    private struct UserNode
    {
      public string FirstName{get;private set;}
      public string LastName{get;private set;}
      public int Age{get;private set;}
      public UserNode(string firstName, string lastName, int age)
      {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
      }
    }
    
    private static IEnumerable<UserNode> ReadUserNodes(string filePath)
    {
      using(FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
      using(XmlReader xrdr = new XmlTextReader(fs))
        while(xrdr.Read())
          if(xrdr.NodeType == XmlNodeType.Element && xrdr.LocalName == "User")
            yield return new UserNode(xrdr.GetAttribute("FirstName"), xrdr.GetAttribute("LastName"), int.Parse(xrdr.GetAttribute("age")));
    }
    
    /*...*/
    
    foreach(UserNode user in ReadUserNodes(@"c:\test.xml"))
    {
      //Do something useful with users...
    }
