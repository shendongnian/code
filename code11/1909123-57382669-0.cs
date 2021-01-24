    public class CriteriaSpecificationForSomeable<T> : ISpecification<T> where T: class, ISomeable
    // ----------------------------------------------------------------------------^^^
    {
    	private Expression<Func<T, bool>> _someCriteria;
    	
    	public CriteriaSpecificationForSomeable()
    	{
    		_someCriteria = e => (e.Some == "Hello");
    	}
    	
        public virtual Expression<Func<T, bool>> Criteria { get { return _someCriteria; } }
    }
