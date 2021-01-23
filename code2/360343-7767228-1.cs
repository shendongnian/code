    public virtual void Freez()
    {
        foreach (var prop in this.GetType().GetProperties())
        {
            if (prop.PropertyType.IsClass && typeof(EntityBase).IsAssignableFrom(prop.PropertyType))
            {
                var value = (EntityBase) prop.GetValue(this, null);
                value.Freez();
            }
    
            if (typeof(ICollection).IsAssignableFrom(prop.PropertyType))
            {
                var collection = (ICollection)prop.GetValue(this, null);
                if (collection != null)
                {
                    foreach (var obj in collection)
                    {
                        if (obj is EntityBase)
                        {
                            ((EntityBase)obj).Freez();
                        }
                    }
                }
            }
        }
    }
