    public interface IId<out T> where T : IUser
    {
        string Value { get; }
    }
    public class Id<T> : IId<T> where T : IUser
    {
        public string Value { get; protected set; }
        protected virtual Id<T> GenerateId() => new Id<T>() { Value = $"{Guid.NewGuid()}" };
        public static Id<T> CreateNew() => Container.GetInstance<Id<T>>().GenerateId();
    }
    public class IndividualId : Id<Individual>
    {
        protected override Id<Individual> GenerateId()
        {
            var instance = new IndividualId();
            instance.Value = $"IndividualId-{Guid.NewGuid()}"; //Example of custom logic
            return instance;
        }
    }
    public class Transaction
    {
        private IId<IUser> _sender;
        private IId<IUser> _receiver;
        public Transaction(IId<IUser> sender, IId<IUser> receiver) { }
    }
