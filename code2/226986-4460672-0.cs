                search.PropertiesToLoad.Add("memberOf");
                StringBuilder groupNames = new StringBuilder(); //stuff them in | delimited
               
                    SearchResult result = search.FindOne();
                    int propertyCount = result.Properties["memberOf"].Count;
                    String dn;
                    int equalsIndex, commaIndex;
    
                    for (int propertyCounter = 0; propertyCounter < propertyCount;
                        propertyCounter++)
                    {
                        dn = (String)result.Properties["memberOf"][propertyCounter];
    
                        equalsIndex = dn.IndexOf("=", 1);
                        commaIndex = dn.IndexOf(",", 1);
                        if (-1 == equalsIndex)
                        {
                            return null;
                        }
                        groupNames.Append(dn.Substring((equalsIndex + 1),
                                    (commaIndex - equalsIndex) - 1));
                        groupNames.Append("|");
                    }
               
                return groupNames.ToString();
 
