    class A
    {
        string s1 = GetString();
        string s2 = this.MyString;
        string s3 = "test";
        public string GetString()
        {
            // this method could use resources that haven't been initialized yet
        }
        public string MyString
        {
            get { return s3; } 
            // this field hasn't been initialized yet 
            // (okay, strings have a default value, but you get the picture
        }
    }
