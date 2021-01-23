    public virtual IEnumerable<IChild> Children
    {
        get
        {
            return _boys.Concat<IChild>(_girls);
        }
    }
