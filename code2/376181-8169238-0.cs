    [Serializable]
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        [NonSerialized]
        private int password;
        public int Password
        {
            get { return password; }
            set { password = value; }
        }
