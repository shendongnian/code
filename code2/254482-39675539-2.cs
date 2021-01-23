     public static string LongestWord2(String statement)
        {
            string max = "";
            foreach (string word in statement.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (word.Length>max.Length)
                {
                    max = word;
                }
            }
            return max;
        }
