    public sealed class CompositeSpecification<T> : ISpecification<T>
    {
        private readonly IList<ISpecification<T>> _specifications;
        public CompositeSpecification(params ISpecification<T>[] specifications)
        {
            _specifications = specifications.ToList();
        }
        public double GetPercentSatisfiedBy(T target)
        {
            return _specifications.Average(
                specification => specification.GetPercentSatisfiedBy(target));
        }
    }
