    public  List<ObjectA> methodA()
    {
        var products = new List<ObjectA>();
        var mre = new ManualResetEvent(false);
        var client = new ServiceReference1.ServiceClient();
        client.getProductCompleted += (s, e) => {
                                                    products.AddRange(
                                                        e.Result.Select(o => 
                                                             new ObjectA(o)));
                                                    mre.Set();
                                                };
    
        client.getProductAsync();
        mre.WaitOne();
    
        return products;
    }
