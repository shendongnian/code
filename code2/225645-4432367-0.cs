    public override bool Equals(object obj)
    {
        if(obj == null)
        {
            return false;
        }
        
        dynamic o = obj;
        return this.Event.Equals(o.Event);
    }
