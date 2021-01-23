    void Add(Unit unit)
    {
        if (unit.GetType() != this.GetType())
        {
            throw new ArgumentException("You can only add measurements.");
        }
    }
