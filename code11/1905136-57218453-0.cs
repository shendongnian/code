    using (var clientContext = new ClientContext("http://sp/sites/test"))
                {
                    string folderName = "test";
                    var list = clientContext.Web.Lists.GetByTitle("ListBase");
                    list.EnableFolderCreation = true;
    
                    clientContext.Load(list);
                    clientContext.Load(list.RootFolder);
                    clientContext.Load(list.RootFolder.Folders);
                    clientContext.ExecuteQuery();
    
                    var folderCollection = list.RootFolder.Folders;
    
                    foreach (var folder in folderCollection)
                    {
                        if (folder.Name == folderName)
                        {
                            clientContext.Load(folder.Files);
                            clientContext.ExecuteQuery();
                        }
                        else
                        {
                            var itemCreateInfo = new ListItemCreationInformation
                            {
                                UnderlyingObjectType = FileSystemObjectType.Folder,
                                LeafName = folderName
                            };
                            var newItem = list.AddItem(itemCreateInfo);
                            newItem["Title"] = folderName;
                            newItem.Update();
                            clientContext.ExecuteQuery();
                            break;
                        }
                    }
                }
