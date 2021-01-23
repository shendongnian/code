        public static int Compute(string word1, string word2)
        {
            int n = word1.Length;
            int m = word2.Length;
            int[,] d = new int[n + 1, m + 1];
            // Step 1
            if (n == 0)
            {
                return m;
            }
            if (m == 0)
            {
                return n;
            }
            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }
            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }
            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (word2[j - 1] == word1[i - 1]) ? 0 : 1;
                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            decimal changesRequired = d[n, m];
            //Find the longest word and calculate the percentage equality
            if (word1.Length > word2.Length)
                return Convert.ToInt32(100 - (changesRequired / word1.Length) * 100);
            else
                return Convert.ToInt32(100 - (changesRequired / word2.Length) * 100);
        }
