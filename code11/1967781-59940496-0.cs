    public bool IsOrdredSubList(List<string> list, List<string> subList)
            {
                int j = 0;
                int cpt = 0;
                bool found = false;
                for (int i = 0; i < list?.Count; i++)
                {
                    if (j < subList?.Count)
                    {
                        if (list[i] == subList[j])
                        {
                            j++;
                            found = true;
                        }
                        if (found) cpt++;
                    }
                }
                return (cpt == subList?.Count);
            }
