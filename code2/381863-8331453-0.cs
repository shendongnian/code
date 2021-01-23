    public override bool Equals(object obj)
    {
        if (obj == null || !(obj == MyClass))
            return false; 
    
        return ((MyClass)obj).Id == this.Id);
    }
