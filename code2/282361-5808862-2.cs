        public string MyString { get; set; }
        public bool MyBool { get; set; }
    
        public override string ToString()
        {
            return "Test Class : " + this.MyString + " - " + MyBool;
        }
    
        public static string operator +(string s, Test t)
        {
            return s + t.ToString();
        }
    }
