    public void MyParallelMethod()
    {
        var data = new List<String>(); 
        //...
        
        Parallel.ForEach(data, d =>
        {
            try
            {
                //...
            }
                   
            catch (Exception e) 
            { 
                //...    
            }
        });
     }
