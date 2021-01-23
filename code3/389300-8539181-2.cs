        static void Main(string[] args)
        {
            List<string> monthList = new List<string>();
            monthList.Add("June");
            monthList.Add("February");
            monthList.Add("August");
            monthList.Sort(new _mysort());
        }
        private class _mysort : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                if (x=="February" && y=="June")
                {
                    return -1;
                }
                return 0;
            }
        }
