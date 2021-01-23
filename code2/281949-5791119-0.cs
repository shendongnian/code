     string xmlContent=@"<?xml version=""1.0"" encoding=""utf-8"" ?>
                                    <PrimaryLink>
                                      <LinkID>p1</LinkID>
                                        <SecondaryLink>
                                          <LinkID>s1</LinkID>      
                                            <LeftMenu>
                                              <NavLinks>
                                                <LinkID>n1</LinkID>
                                              </NavLinks>
                                              <NavLinks>
                                                <LinkID>n2</LinkID>               
                                              </NavLinks>
                                            </LeftMenu>
                                        </SecondaryLink>  
                                    </PrimaryLink>";
            XDocument doc = XDocument.Parse(xmlContent);
            var targetNode = doc.Descendants().Where(p=>p.Value=="n1").FirstOrDefault();
            string path = null;
            if (targetNode!=null)
            {
                path=targetNode.AncestorsAndSelf().Elements("LinkID").Select(p => p.Value).Aggregate((i, j) => j + "=>" + i);
            }
