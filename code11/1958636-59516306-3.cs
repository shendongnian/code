    public class DiscountRuleChain : RuleChain<ApplyDiscountContext> {
        private readonly IServiceProvider services;
        public DiscountRuleChain(IServiceProvider services) {
            this.services = services;
        }
        protected override object GetService(Type type, params object[] args) =>
            args == null || args.Length == 0
                ? services.GetService(type)
                : Activator.CreateInstance(type, args);
    }
    
