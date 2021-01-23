        public static string FirstCap(string value)
        {
            string result = String.Empty;
            if(!String.IsNullOrEmpty(value))
            {
                if(value.Length == 1)
                {
                    result = value.ToUpper();
                }
                else
                {
                    result = value.Substring(0,1).ToString().ToUpper() + value.Substring(1).ToLower();
                }
            }
            return result;
        }
