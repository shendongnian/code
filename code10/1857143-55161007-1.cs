    public class Config
    {
        private string host { get; set; }
        private string user_name { get; set; }
        public string Uri
        {
            get
            {
                return host;
            }
            set
            {
                host = value;
            }
        }
        public string UserName
        {
            get { return user_name; }
            set
            {
                user_name = value;
            }
        }
        public string Password { get; set; }
    }
