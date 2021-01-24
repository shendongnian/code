                String fileToUpload = "C:/Users/Administrator.CONTOSO2016/Desktop/Test.txt";
                String sharePointSite = "http://sp2016/sites/dev/";
                String libraryName = "Documents";
                String fileName = fileToUpload.Substring(fileToUpload.LastIndexOf("\\") + 1);
                using (ClientContext context = new ClientContext(sharePointSite))
                {
                    FileCreationInformation FCInfo = new FileCreationInformation();
                    FCInfo.Url = "http://sp2016/sites/dev/Shared%20Documents/Test.txt";
                    FCInfo.Overwrite = true;
                    FCInfo.Content = System.IO.File.ReadAllBytes(fileToUpload);
    
                    Web web = context.Web;
                    List library = web.Lists.GetByTitle(libraryName);
                    Microsoft.SharePoint.Client.File uploadfile = library.RootFolder.Files.Add(FCInfo);
                    uploadfile.CheckIn("testcomment",CheckinType.MajorCheckIn);
                    context.ExecuteQuery();
    
                }
                Console.WriteLine("Success");
