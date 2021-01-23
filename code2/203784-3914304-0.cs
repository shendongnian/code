    thingamajigCollection = thingamajigLocators
                            .Select(tl => 
                                 {
                                 try
                                     {
                                         return thingamajigservice.GetThingamajig(tl);
                                     }
                                 catch(Exception)
                                     {
                                         return null;
                                     }
                                 })
                              .Where(t1 => t1!=null);
