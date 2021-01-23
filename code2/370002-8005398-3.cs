    public User GetUserByCode(string Code)
    {
        User userInstance = null;
        string xpath = "Users/User[@Code="+ Code +"]";
        XmlNode user = _xmlDatabase.SelectSingleNode(xpath);
        if (user != null)
        {
            XmlAttributeCollection userMeta = user.Attributes;
            if (userMeta != null)
            {
                int code = int.Parse(Code);
                userInstance = new User(Code, userMeta[1].Value, userMeta[2].Value);
            }
        }
    
        return userInstance;
    }
