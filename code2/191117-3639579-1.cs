    public virtual Unit Add(Unit other)
    {
       if(this.GetType != other.GetType())
          throw new ArgumentException("Units being added must be of same type");
    }
