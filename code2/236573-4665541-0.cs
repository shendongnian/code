    public object Clone()
    {
        Type type = this.GetType();
        Loot newLoot = (Loot) Activator.CreateInstance(type);
        //do copying here
        return newLoot;
    }
