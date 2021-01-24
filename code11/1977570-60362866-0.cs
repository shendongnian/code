                string s = "srmbscsrm $bsc $ srmbsc $";
                string result = string.Empty;
                char t = $;
                int count = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == t)
                    {
                        count++;
                        if (count == 1)
                        {
                            result += s[i];
                        }
                    }
                    else
                    {
                        result += s[i];
                    }
                }
