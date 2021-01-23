    public override int GetHashCode()
    {
        return this.EventId;
    }
    
    public override bool Equals(object other)
    {
        if (other is Pay)
            return ((Pay)other).EventId = this.EventId;
        return false;
    }
