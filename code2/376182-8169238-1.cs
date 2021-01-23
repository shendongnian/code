    [Serializable]
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        [ScriptIgnore]
        public int Password {get; set;}
    }
