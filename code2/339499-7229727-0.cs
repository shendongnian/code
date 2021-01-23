    IEnumerable<UserInfo> GetUsers()
    {
        XDocument users = XDocument.Load(path);
        return from u in users.Descendants("user")
               select new UserInfo
               {
                   Name = (string)u.Attribute("name"),
                   Password = (string)u.Attribute("password"),
                   Email = (string)u.Attribute("email")
               };
    }
    IEnumerable<UserInfo> users = GetUsers();
    UserInfo userUser = users.FirstOrDefault(u => u.Name == "user");
