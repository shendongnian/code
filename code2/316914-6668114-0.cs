    [Serializable]
    class PrintUser : IEquatable<PrintUser>
    {
        public string Username { get; private set; }
        public int PageLimit { get; set; }
        public bool LimitEnforced { get; set; }
        public PrintUser(string userName)
        {
            this.Username = userName;
        }
        public bool Equals(PrintUser other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return this.Username == other.Username;
            }
        }
    }
