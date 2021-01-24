    public override bool Equals(object obj)
    {
        if (!(obj is B other))
        {
            return false;
        }
        
        if (this.Prop == null || other.Prop == null)
        {
            return false;
        }
    
        return this.Prop.SequenceEqual(other.Prop);
    }
