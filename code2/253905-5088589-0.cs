        using (DirectoryEntry entry = new DirectoryEntry())
        {
            using (DirectorySearcher searcher = new DirectorySearcher(entry))
            {
                searcher.Filter = "yourSearchQuery";
                searcher.PropertiesToLoad.Add("yourProperty1");
                searcher.PropertiesToLoad.Add("yourProperty2");
                using (SearchResultCollection results = searcher.FindAll())
                {
                    foreach (SearchResult result in results)
                    {
                        using (DirectoryEntry resultEntry = result.GetDirectoryEntry())
                        {
                            PropertyValueCollection valuesForProperty1 = resultEntry.Properties["yourProperty1"];
                            PropertyValueCollection valuesForProperty2 = resultEntry.Properties["yourProperty2"];
                            // ...
                        }
                    }
                }
            }
        }
