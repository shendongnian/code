    class Group
    {
        public string FirstName { get; private set;}
        public string LastName { get; private set;}
        [...]
        public Group(string returnStr)
        {
            string[] strGroup=returnStr.split(',');
            [...]
            this.FirstName = strGroup[22];
            this.LastName = strGroup[23];
            [...]
        }
     }
