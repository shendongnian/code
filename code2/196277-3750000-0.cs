        private List<string> FindAll(List<string> list, string pattern)
        {       // returns found results
                return list.FindAll(delegate(string item)
                                {
                                    return item.Contains(pattern);
                                  
                                });
        }
