           static void Main(string[] args)
            {
                ClientContext clientContext=new ClientContext("http://sp/");
                ContentType cType = null;
                try
                {
                        cType = clientContext.Web.ContentTypes.GetById("0x0101004B81B8917C303D47BEA5E576CB73DF88");
                        clientContext.Load(cType);
                        clientContext.ExecuteQuery();
                
               
                        if (!string.IsNullOrEmpty(cType.Name))
                        {
                            cType = clientContext.Web.ContentTypes.GetById("0x0120D520A808");
    
                        }
                        else
                        {
                            Console.WriteLine("Content Type not existed in current web.");
                        }
                }
                catch (Microsoft.SharePoint.Client.ServerObjectNullReferenceException nullException)
                {
                    
                }
            }
