    class HasManyConvention : IHasManyConvention, IHasManyConventionAcceptance
    {
        public void Accept(IAcceptanceCriteria<IOneToManyCollectionInspector> criteria)
        {
            criteria.Expect(x => x.Name == "HasInitialed"); // and/or entity type
        }
        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Key.Column(((ICollectionInspector)instance).Name + "_id");
        }
    }
