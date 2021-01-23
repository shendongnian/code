    int FindCount(string keyword, string input)
        {
            if (input.Contains(keyword))
            {
                int count = 0;
                int i = 0;
                foreach (var c in input)
                {
                    if (c == keyword[i])
                        i++;
                    else
                        i = 0;
                    if (i == keyword.Length)
                    {
                        i = 0;
                        count++;
                    }
                }
                return count;
            }
            
            return 0;
        }
