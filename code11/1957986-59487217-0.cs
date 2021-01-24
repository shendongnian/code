    public static string SplitString(string data,int size)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                if (i % size == 0)
                    sb.Append(' ');
                sb.Append(data[i]);
            }
            return sb.ToString();
        }
 
