    private sealed class CollectionClass : SubClass<IEnumerable<BaseClass>>
    {
        public IEnumerable<BaseClass> Components { get=>Value; set=>Value=value; }
        
        //this prevents value to be serialized for this type of class
        public override bool ShouldSerializeValue() => false;
    }
