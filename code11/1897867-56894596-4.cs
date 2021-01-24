    class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine("start");
                    byte[] b = System.IO.File.ReadAllBytes(@"[PATH TO FILE LIKE C:\test.png]");
                    using (ClientContext context = new ClientContext("[SITECOLLECTION URL]"))
                    {
                        List list = context.Web.Lists.GetByTitle("[LIB NAME LIKE 'DOCUMENTS']");
                        FileCreationInformation fileInfo = new FileCreationInformation();
                        fileInfo.Content = b;
                        fileInfo.Overwrite = true;
    
                        fileInfo.Url = "[SITECOLLECTION URL]" + "/[LIB NAME FROM URL LIKE 'DOCUMENTS']/" + "[FILE NAME LIKE 'test.png']";
                        Microsoft.SharePoint.Client.File uploadFile = list.RootFolder.Files.Add(fileInfo);
    
                        uploadFile.ListItemAllFields.Update();
                        context.ExecuteQuery();
                    }
                    Console.WriteLine("end");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error -> " +  ex.Message);
                }
                finally
                {
                    Console.ReadLine();
                }
            }
        }
