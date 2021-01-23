    public ObjectPropertyMapping()
    {
        References(x => x.Object).Index("IX_OBJECT");
        Map(x => x.Name).Index("IX_OBJECT");
    }
