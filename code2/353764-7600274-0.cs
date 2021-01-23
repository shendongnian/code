    ItemTemplate item = new ItemTemplate();
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("/Items.xml", FileMode.Open))
                {
                    XElement doc = XElement.Load(stream);
                    IEnumerable<XElement> itemTest = from el in doc.Elements("item")
                                                     where (string)el.Element("id") == itemId
                                                     select el;
                    foreach (XElement el in itemTest)
                    {
                        item.ItemContent = el.Element("content").Value;
                        item.Status = Convert.ToBoolean(el.Element("status").Value);
                        item.Notes = el.Element("notes").Value;
                        item.Location = el.Element("location").Value;
                        item.Deadline = Convert.ToDateTime(el.Element("deadline").Value);
                    }                  
                }
            }
