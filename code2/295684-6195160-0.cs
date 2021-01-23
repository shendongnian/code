     var reusableSW = new LC.Utils.WCF.ServiceWrapper<IProcessDataDuplex>(channelFactory);
    
     reusableSW.Reuse(client =>
                          {
                              client.CheckIn(count.ToString());
                          });
     reusableSW.Dispose();
