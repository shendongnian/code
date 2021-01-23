    public int Size 
    {
        get
        {
             return GetNumber(this.productSize);
        }
    }
    ...
    d.OrderBy(x=>x.Size);
    
