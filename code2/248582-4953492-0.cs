    public Program()
            {                
                    Console.WriteLine("This is the SERVER console");
    
                    var myUri = new Uri[1];                    
                    myUri[0] = new Uri(ConfigurationManager.AppSettings["baseAddress"]);
    
                    var timeEntryService = new WCFTimeEntryService();    
                    var host = new ServiceHost(timeEntryService, myUri);    
                    host.Open();
    
                    Console.WriteLine("Service Started!");    
                    Console.WriteLine("Click any key to close...");
                    Console.ReadKey();
    
                    host.Close();    
                
            }
