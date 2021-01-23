    class Bool2CharArrayConverter
    {
        public static string ConvertArray(bool[] Input)
        {
            int asc = 65;
            string response = string.Empty;
            foreach (bool val in Input)
            {
                if (val)
                {
                    response += Convert.ToChar(asc);
                }
                asc++;
            }
            return response;
        }
    }
