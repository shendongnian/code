    public  List<ObjectA> methodA()
    {
        var products = new List<ObjectA>();
        var mre = new ManualResetEvent(false);
        var client = new ServiceReference1.ServiceClient();
        client.getProductCompleted += (s, e) => {
                                                   try
                                                   {
                                                       products.AddRange(
                                                           e.Result.Select(o => 
                                                                new ObjectA(o)));
                                                   }
                                                   finally
                                                   {
                                                       mre.Set();
                                                   }
                                                };
    
        client.getProductAsync();
        mre.WaitOne();
    
        return products;
    }
