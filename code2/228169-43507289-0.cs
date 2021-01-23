    class User
    {
        public string username { set; get; }
        public string userid { set; get; }
        public override string ToString()
        {
            return ($"{username}");
        }
    }
