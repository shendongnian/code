    public class Id<T>
    {
        public string Value { get; protected set; }
        protected virtual Id<T> GenerateId() => new Id<T>() { Value = $"Guid.NewGuid" };
        public static Id<T> CreateNew() => Container.GetInstance<Id<T>>().GenerateId();
    }
    public class IndividualId : Id<Individual>
    {
        protected override Id<Individual> GenerateId()
        {
            var instance = new IndividualId();
            instance.Value = $"IndividualId-{Guid.NewGuid()}";
            return instance;
        }
    }
