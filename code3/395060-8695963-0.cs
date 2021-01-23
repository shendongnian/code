        using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
    
            namespace yournamespace
            {
              public class User
              {
               private static User u;
               public string Username
               { get { return _username; } }
    
               private string _username;
               protected User(){}
    
              public void SetUserInformation(string uname)
              {
                
               _username = uname;
          
              }
    
             public static User Instance
             {
              get{
               if(u==null)
                 u=new User();
               return u;
              }
            }
    
    #if(TEST_USER)
        public static void Main(string[] args)
        {
          User u = User.Instance;
          u.SetUserInformation("testuser");
          User u1 = User.Instance;
        }
    #endif
      }
    }
