    public override bool Equals (object obj)
    {
        if ( EqualsStrategy != null)
        {
            return EqualsStrategy.Equals(this,object);
        }
        else
        {
           return base.Equals(obj);
        }
    }
