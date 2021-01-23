    public class GenericValidator<T> : IValidator<T>
    {
        private readonly IEnumerable<IRule<T>> _rules;
        public GenericValidator(IRuleFactory<T> ruleFactory){
            _rules = ruleFactory.BuildRules();
        }
        public bool IsValid(T obj){
            return _rules.All(p => p.IsValid(obj));
        }
    }
    public class GenericRuleFactory<T> : IRuleFactory<T>
    {
        private readonly IEnumerable<IRule<T>> _rules;
        public GenericRuleFactory(IEnumerable<IRule<T>> rules){
            _rules = rules;
        }
        public IEnumerable<IRule<T>> BuildRules(){
            return _rules.Where(x => x.WithinScope());
        }
    }
