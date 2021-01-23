    while (!CheckConstraints(a))
    {
        a.Change();
    }
    bool CheckConstraints(Thing a)
    {
        return Constraints.All(c => c.Allows(a));
    }
