    while (!MeetsConstraints(a))
    {
        a.Change();
    }
    bool MeetsConstraints(Thing a)
    {
        return Constraints.All(c => c.Allows(a));
    }
