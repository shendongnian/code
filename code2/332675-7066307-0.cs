    public int SaveThis()
    {
        return -1 //return identity
    }
    
    public int SaveThat(int thisID)
    {
        return -2 //return identity
    }
    
    public void SaveThisAndThat()
    {
        int thisID = this.SaveThis();
        int thatID = this.SaveThat(thisID);
        
        //so on and so forth    
    }
