    public Int32 MaxIndex { get; set; }
    public Int32 GetNewIndex()
    {
         
        this.MaxIndex += 1;
        return this.MaxIndex;
        
    }
