    if (string.IsNullOrEmpty(filename) || GoodSize(size))
    {
     //...
    }
    
    private bool GoodSize(string size)
    {
       return size != "Large" || size != "Medium" || size != "Small";
    }
