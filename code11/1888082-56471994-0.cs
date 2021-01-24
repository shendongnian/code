            ListItemCollection listItems = list.GetItems(camlQuery);
            clientContext.Load(listItems);
            clientContext.ExecuteQuery();
            foreach (var item in listItems)
            {
                if (item.FileSystemObjectType == FileSystemObjectType.File)
                {
                    Console.WriteLine("This is file");
                    clientContext.Load(item.File);
                    clientContext.ExecuteQuery();
                    
                    var fileRef = item.File.ServerRelativeUrl;
                    var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(clientContext, fileRef);
                    var fileName = Path.Combine(@"D:\", (string)item.File.Name);
                    using (var fileStream = System.IO.File.Create(fileName))
                    {
                        fileInfo.Stream.CopyTo(fileStream);
                    }
                }
                else if (item.FileSystemObjectType == FileSystemObjectType.Folder)
                {
                    Console.WriteLine("This is folder");
                }
            }
