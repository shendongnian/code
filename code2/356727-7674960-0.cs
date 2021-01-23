    class MyJoinedSubclassConvention : IJoinedSubclassConvention, IJoinedSubclassConventionAcceptance
    {
        public void Accept(IAcceptanceCriteria<IJoinedSubclassInspector> criteria)
        {
            criteria.Expect(x => x.Name == "ConfiguredPhoneNumberBlockEntity");
        }
        public void Apply(IJoinedSubclassInstance instance)
        {
            instance.Key.Column("baseclassId");
        }
    }
