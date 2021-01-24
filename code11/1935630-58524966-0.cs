     public static void GetConsecutiveMatch(List<String> items, String match, out List<int> indices)
        {
            indices = new List<int>();
            for (int i = 0; i < items.Count(); i++)
            {
                var strToCompare = "";
                for (int j = i ;  j < items.Count(); j++)
                {
                    strToCompare += items[j];
                    if (strToCompare.Length == match.Length)
                    {
                        if (strToCompare == match)
                        {
                            indices.Clear();
                            for (int k = i; k <= j; k++)
                            {
                                indices.Add(k + 1); // at your example indices seems to be starting at 1, so I added 1 to the actual index
                            }
                        }
                        break;				
                    }
                    else if (strToCompare.Length > match.Length)
                    {
                        break;
                    }
                }
            }
        }
