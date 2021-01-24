       public static int FindShort(string sentence)
       {
            if(!string.IsNullOrEmpty(sentence))
            {
                   return Regex.Split(sentence, @"\s+").OrderBy(x1 => x1.Length).ToList().First().Length;
            }
            return -1;
        }
