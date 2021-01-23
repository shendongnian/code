    SPFarm farm = SPFarm.Local;
                SPWebService service = farm.Services.GetValue<SPWebService>("");
                foreach (SPWebApplication webapp in service.WebApplications)
                {
                    foreach (SPSite sitecoll in webapp.Sites)
                    {
                        foreach (SPWeb web in sitecoll.AllWebs)
                        {
                            <<Use recursion here to Get sub WebS>>
                            web.Dispose(); 
                        }
    
                        sitecoll.Dispose();   
    
                    }
    
                }
