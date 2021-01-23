        public static string MyWeirdFormat(this string str)
        {
            return string.Format("{0} is weird",str);
        }
        public static void Test()
        {
            string myString = "ABCD";
            string weirdString =  myString.MyWeirdFormat();
        }
