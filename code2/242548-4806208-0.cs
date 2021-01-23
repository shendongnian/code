    bool ISet<TObject>.Add(TObject item) 
    {
        return(Add(item));
    }
    void ICollection<TObject>.Add(TObject item)
    {  
        **return(Add(item))**;
    }
    public new virtual bool Add(TObject item)
    {
        // my actual add code
    }
