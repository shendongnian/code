        string Strip(string arg)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in arg.ToCharArray())
            {
                if ((c >= '0') && (c <= '9'))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
