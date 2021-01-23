    new Thread(() =>
                               {
                                   new Thread(() =>
                                   {
                                       _priceA = _service.GetPriceA();
                                       _waithandle[0].Set();
                                   }).Start();
    
                                   new Thread(() =>
                                   {
                                       _priceB = _service.GetPriceB();
                                       _waithandle[1].Set();
                                   }).Start();
    
                                   WaitHandle.WaitAll(_waithandle);
                                   PriceA = _priceA;
                                   PriceB = _priceB;
                               }).Start();
