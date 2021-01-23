    class Bool2CharArrayConverter
    {
        public static string ConvertArray(bool[] Input)
        {
            int asc = 65;
            StringBuilder response = StringBuilder();
            foreach (bool val in Input)
            {
                if (val)
                {
                    response.Append( Convert.ToChar(asc));
                }
                asc++;
            }
            return response.ToString();
        }
    }
