                var scope = new System.Management.ManagementScope();
                var q = new System.Management.ObjectQuery("SELECT * FROM CIM_VideoControllerResolution");
    
                using (var searcher = new System.Management.ManagementObjectSearcher(scope, q))
                {
                    var results = searcher.Get();
                    foreach (var item in results)
                    {
                        Console.WriteLine(item["Caption"]);
                    }
                }
