    namespace Store_Passwords_and_Serial_Codes
    {
        class AddEntry
        {
            // Auto properties make this class a lot easier to read.
            public string type { get; set; }
            public string url { get; set; }
            public string softwareName { get; set; }
            public string serialCode { get; set; }
            public string userName { get; set; }
            public string password { get; set; }
            // Non-default constructor.
            public AddEntry(string type, string url, string softwareName, string serialCode, string userName, string password)
            {
                this.type = type;
                this.url = url;
                this.softwareName = softwareName;
                this.serialCode = serialCode;
                this.userName = userName;
                this.password = password;
            }
        }
    }
