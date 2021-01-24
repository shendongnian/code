    namespace UnNamed Project
    {
        abstract class User
        {
            private string _name;
            private int _securityLevel;
    
            public User(string name, int securityLevel)
            {
                _name = name;
                _securityLevel = securityLevel;
            }
    
            abstract public bool Login();
        }
    }
