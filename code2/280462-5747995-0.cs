    public static List<int> CharOccurs(string stringToSearch, char charToFind)
            {
                List<int> count = new List<int>();
                int  chr = 0;
                while (chr != -1)
                {
                    chr = stringToSearch.IndexOf(charToFind, chr);
                    if (chr != -1)
                    {
                        count.Add(chr);
                        chr++;
                    }
                    else
                    {
                        chr = -1;
                    }
                }
                return count;
            }
