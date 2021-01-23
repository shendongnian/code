    # User.cs
    namespace LDIFMod
    {
        public class User
        {
            User()
            {
                UserDict = new Dictionary<string, string>()
            }
            public string UserHash { get; set; }
            public string UserID { get; set; }
            public Dictionary<string, string> UserDict { get; private set; }
        }
    
    }
