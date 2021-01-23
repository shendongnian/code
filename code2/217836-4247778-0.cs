    public Composite CreateSpellCheckAndCast(string name)
    {
        return new Decorator(
            ret => Spells.CanCast(name),
            new Action(ret => Spells.Cast(name)));
    }
