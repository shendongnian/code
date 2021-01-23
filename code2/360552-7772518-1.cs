    public class LongStringConvention : IPropertyConvention, IPropertyConventionAcceptance
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Type == typeof(string));
        }
    
        public void Apply(IPropertyInstance instance)
        {
            instance.Length(4001);
        }
    }
