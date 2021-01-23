      public List<string> permute(string value, string prefix = "")
        {
            List<string> result = new List<string>();
            for (int x=0;x<value.Length;x++)
            {
                result.Add(prefix + value[x]);
                result.AddRange(permute( value.Remove(x, 1), prefix + value[x]));
            }
            return result;
        }
