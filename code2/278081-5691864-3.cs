        public static string smallNumBigNumProduct(string a, string b)
        {
              // NOTE no error checking for bad input or possible overflow...
            int num1 = Convert.ToInt32(a);
            int num2 = Convert.ToInt32(b);
            return ((num1*num2).ToString());
        }
