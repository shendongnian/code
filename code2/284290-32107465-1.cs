    class Base
    {
        private static Dictionary<string, int> myStaticFieldDict = new Dictionary<string, int>();
        public int MyStaticField
        {
            get
            {
                return myStaticFieldDict.ContainsKey(this.GetType().Name)
                       ? myStaticFieldDict[this.GetType().Name]
                       : default(int);
            }
            set
            {
                myStaticFieldDict[this.GetType().Name] = value;
            }
        }
        void MyMethod()
        {
            MyStaticField = 42;
        }
    }
