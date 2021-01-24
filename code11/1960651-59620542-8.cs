    public List<MyObjectDTO> MyObjectSearchResults(string keystrokes)
        {
            //TODO: encapsulate in a View
            List<MyObjectDTO> searchResults = null;
            IEnumerable<MyObjectDTO> queryResults;
                queryResults = from site in MyObjects
                               where site.Name.ToLower().Contains(keystrokes.ToLower())
                               select site;
                if (string.IsNullOrEmpty(SearchString))
                {
                    QueryResults = MyObjects;
                }
                else
                {
                    QueryResults = queryResults.ToList<MyObjectDTO>();
                    ListHeight = QueryResults.Count * 45; //TODO: detect size. magic number of 45 limits the height. 
                }
            return searchResults;
        }
