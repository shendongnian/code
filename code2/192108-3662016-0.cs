    class StringOrDouble
    {
        private double d;
        private string s;
        private bool isString;
        StringOrDouble(double d)
        {
            this.d = d;
            isString = false;
        }
        StringOrDouble(string s)
        {
            this.s = s;
            isString = true;
        }
        double D
        {
            get
            {
                if (isString)
                    throw new InvalidOperationException("this is a string");
                return d;
            }
        }
        string S
        {
            get
            {
                if (!isString)
                    throw new InvalidOperationException("this is a double");
                return s;
            }
        }
        bool IsString { get { return isString; } }
    }
