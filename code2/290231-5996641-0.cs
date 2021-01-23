    Dictionary<string, string> userName_Pwd_Cache = new Dictionary<string, string>();
    //caching username/password code
    
        if(userName_Pwd_Cache.ContainsKey(userNameVar)) //let userNameVar is entered username
        {
               if(userName_Pwd_Cache[userNameVar] == passwordVar) //let passwordVar is entered passwords
               {
                   //user authenticated
               }
               else
               {
                   //authentication failed 
               }
        }
