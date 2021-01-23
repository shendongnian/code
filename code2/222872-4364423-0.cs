    public override bool Equals(object obj)
    {
        var other = obj as MyTest;
        if (other == null)
        {
            return false;
        }
        return other.me == me;
    }
