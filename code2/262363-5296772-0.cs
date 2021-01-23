    public class MyDataObject
    {
        public int MyValue1 { get; set; }
        public string MyValue2 { get; set; }
        public decimal MyValue3 { get; set; }
        public decimal MyTotal
        {
            get
            {
                return MyValue1
                        + MyValue3
                        + (string.IsNullOrWhiteSpace(MyValue2) ? 0 : Convert.ToInt32(MyValue2));
            }
        }
        //alternate version:
        public decimal MyTotal2
        {
            get
            {
                return MyValue1 + MyValue3 + ConvertToInt(MyValue2, 0);
            }
        }
        //helper method:
        private int ConvertToInt(string input, int defaultVal)
        {
            int temp = 0;
            if (int.TryParse(input, out temp))
                return temp;
            return defaultVal;
            //this can also be written more succinctly as:
            //return int.TryParse(input, out temp) ? temp : defaultVal;
        }
    }
