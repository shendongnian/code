       if (user != null) // if user == null nothing will return 
        {
            XmlAttributeCollection userMeta = user.Attributes;
            if (userMeta != null) // if userMeta == null nothing will return 
            {
                int code = int.Parse(Code);
                User userInstance = new User(Code, userMeta[1].Value, userMeta[2].Value);
                return userInstance;
            }
        }
