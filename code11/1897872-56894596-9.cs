    class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine("start");
                    using (ClientContext context = new ClientContext("[SITECOLLECTION URL]"))
                    {
                        using (FileStream fs = new FileStream(@"[PATH TO FILE LIKE C:\test.png]", FileMode.Open))
                        {
                            Microsoft.SharePoint.Client.File.SaveBinaryDirect(context, "/[LIB NAME FROM URL LIKE 'DOCUMENTS']/" + "[FILE NAME LIKE 'test.png']", fs, true);
                        }
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
