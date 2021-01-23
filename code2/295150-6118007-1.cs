    class SiteVariables
    {
        private static _myVariable = 0;
        public static int MyVariable
        {
            get { return _myVariable; }
            set { _myVariable = value; }
        }
    }
