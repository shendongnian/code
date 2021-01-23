        public ArrayList AttributeValuesMultiString(string attributeName,
             string objectDn, ArrayList valuesCollection, bool recursive)
        {
            using (DirectoryEntry ent = new DirectoryEntry(objectDn))
            {
                using (DirectorySearcher searcher = new DirectorySearcher(ent))
                {
                    searcher.PropertiesToLoad.Add(attributeName);
                    var result = searcher.FindOne();
                    ResultPropertyValueCollection ValueCollection = result.Properties[attributeName];
                    IEnumerator en = ValueCollection.GetEnumerator();
                    while (en.MoveNext())
                    {
                        if (en.Current != null)
                        {
                            if (!valuesCollection.Contains(en.Current.ToString()))
                            {
                                valuesCollection.Add(en.Current.ToString());
                                if (recursive)
                                {
                                    AttributeValuesMultiString(attributeName, "LDAP://" +
                                    en.Current.ToString(), valuesCollection, true);
                                }
                            }
                        }
                    }
                }
            }
            return valuesCollection;
        }
