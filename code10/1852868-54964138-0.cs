    class MyStr
    {
        private string _name;
        // Constructor. Has same name as class. Doesn't have a return type.
        public MyStr(string name)
        {
            _name = name;
        }
        public string ReverseStr()
        {
            string temp = "";
            int i, j;
            for (j = 0, i = _name.Length - 1; i >= 0; i--, j++)
                temp += _name[i];
            return temp;
        }
    }
