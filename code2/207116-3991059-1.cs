    public void Baz(ref StringBuilder b)
    {
        // This change *will* be seen
        b = new StringBuilder();
    }
