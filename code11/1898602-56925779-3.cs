    class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine("start " + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString());
    
                    using (ClientContext context = new ClientContext("[SITECOLLECTION URL]"))
                    {
                        context.RequestTimeout = -1;
                        Web web = context.Web;
                        if (context.HasPendingRequest)
                            context.ExecuteQuery();
                        byte[] fileBytes = System.IO.File.ReadAllBytes(@"[PATH TO FILE LIKE C:\test.png]");
                        using (var fileStream = new System.IO.MemoryStream(fileBytes))
                        {
                            Microsoft.SharePoint.Client.File.SaveBinaryDirect(context, "/[LIB NAME FROM URL LIKE 'DOCUMENTS']/" + "[FILE NAME LIKE 'test.png']", fileStream, true);
                        }
                    }
    
                    Console.WriteLine("end " + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error -> " + ex.Message);
                }
                finally
                {
                    Console.ReadLine();
                }
            }
        }
