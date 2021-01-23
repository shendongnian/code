    public XElement AsXml( )
    {
        return new XElement(@"ThisThing,
            _myBoolean.AsZeroOrElementNamed(@"MyBoolean"),
            _myString.AsElementNamed(@"MyString")
    }
