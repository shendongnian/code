    public virtual IEnumerable<IChild> Children // .NET 2.0 and greater
    {
        get
        {
            foreach (IChild boy in _boys)
                yield return boy;
            foreach (IChild girl in _girls)
                yield return girl;
        }
    }
