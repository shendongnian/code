    ArrayList myArrayList = new ArrayList();
    int iCount = 0;
    
    if (parsedData.Count > 0)
                    {
                        foreach (var item in parsedData)
                        {
                            myArrayList.Add(new Identifier() { Id = item.First() });
                            iCount++;
                            if (iCount % 10 == 0)
                            { 
                                  ServiceReference.CustomerProfileServiceClient clientObj = new ServiceReference.CustomerProfileServiceClient();
                                  var responseObj = clientObj.GetProfiles( myArrayList.ToArray(typeof(Identifier)) as Identifier[]);
                                  myArrayList.Clear();
                            }
                        }
                    }
