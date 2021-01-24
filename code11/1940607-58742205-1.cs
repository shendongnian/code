    public class LeaseCalculatorBuilder
    {
        internal Dictionary<Type, Func<ILeasable, int>> Calculations { get; } = new Dictionary<Type, Func<ILeasable, int>>();
        internal LeaseCalculatorBuilder On<T>(Func<T, int> calculation) where T : class, ILeasable
        {
            Calculations.Add(typeof(T), (ILeasable c) => calculation((T)c));
            return this;
        }
        internal LeaseCalculator Build(LeasableRepository leasableRepository)
        {
            return new LeaseCalculator(leasableRepository, this);
        }
    }
    public class LeaseCalculator
    {
        private readonly Dictionary<Type, Func<ILeasable, int>> _calculations;
        private readonly LeasableRepository _leasableRepository;
        internal LeaseCalculator(LeasableRepository leasableRepository, LeaseCalculatorBuilder builder)
        {
            _leasableRepository = leasableRepository;
            _calculations = builder.Calculations;
        }
        public int CalculateLease(int id)
        {
            ILeasable property = _leasableRepository.GetLeasable(id);
            Type type = property.GetType();
            if (_calculations.TryGetValue(type, out var calculation))
            {
                return calculation(property);
            }
            throw new Exception("Unexpected type, please extend the calculator");
        }
    }
