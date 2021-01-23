    class Entry { }
     
    class PCPassword : Entry
    {
        string userName { get; set; }
        string password { get; set; }
        public PCPassword(string uName, string pass)
        {
            this.userName = uName;
            this.password = pass;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("User Name: " + this.userName);
            sb.AppendLine("Password: " + this.password);
            sb.AppendLine();
            return sb.ToString();
        }
    }
    
