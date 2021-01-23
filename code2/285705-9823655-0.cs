    public static void DetermineSprintCorporateLiableCustomer()///method get call in unit test
    {
                COptions p2 = new COptions();  
                MGetCOptions.CustomerInfoCallerOptionsRef = (ref COptions p1) =>
                    {
                        if (p1 != null && p1 != null && p1.Type.Equals("Data", StringComparison.OrdinalIgnoreCase))
                        {
                            p1.Type = "P";
                            p1.Indicator = true; 
                        }
                        p2 = p1;
                    };
            }
