    var locations = from s in xdoc.Descendants("RECORD")
                            select new Location
                                       {
                                           Id = IdList.Contains(s.Element("ID1").Value) ? 
                                           s.Element("ID1").Value : 
                                             (IdList.Contains(s.Element("ID2").Value) ? 
                                              s.Element("ID2").Value : 
                                              DefaultValue)
                                       }; 
