    List<String> userList = new List<String>();
    String userData = "User1,User2,User3";
    userList.AddRange(userData.Split(',').Select(x => String.Format("\"{0}\"", x)));
    // check area
    for(int i = 0; i < userList.Count; i++)
    {
         Console.WriteLine(userList[i]);
    }
