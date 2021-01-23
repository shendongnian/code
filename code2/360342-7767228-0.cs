    public virtual void Freez()
    {
        foreach (var prop in this.GetType().GetProperties())
        {
            if (prop.PropertyType.IsClass && typeof(EntityBase).IsAssignableFrom(prop.PropertyType))
            {
                var value = (EntityBase) prop.GetValue(this, null);
                value.Freez();
            }
        }
    }
