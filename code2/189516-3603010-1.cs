        string Strip(string arg)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in arg.ToCharArray())
            {
                if (char.IsDigit(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
