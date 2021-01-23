    # User.cs
    namespace LDIFMod
    {
        public class User
        {
            public string UserHash { get; set; }
            public string UserID { get; set; }
            public readonly string[] SourceData {get; private set;}
        }
    }
