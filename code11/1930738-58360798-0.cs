    public bool DataIsValid(string s, Type someType) {
        o = 0; // a class member object variable
        try { o = Convert.ChangeType(s, someType); }
        catch { return false; }
        
        return true;
    }
    
    //using the object variable
    double someDouble = (double)0;
    //some more code
