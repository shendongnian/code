    town.TownName = $"{weatherRoot.Name}";
                    town.Temp = Temp;
                    town.searchTime = DateTime.Now.ToString();
                    
                    //history database push               
                    try
                    {      
                        var returnvalue = searchHistoryDataController.AddTown(town);
    
                        if (returnvalue == "Sucessfully Added")
                        {
    
                            Console.WriteLine("Success");
                        }
                        else
                        {
                            Console.WriteLine("Fail");
                        }                
                    }
                    catch (Exception es)
                    {
                        Debug.WriteLine(es.Message);
                    }
    
                    TownList = searchHistoryDataController.OrderItemCollection;
