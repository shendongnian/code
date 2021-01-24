    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method)]
    [MulticastAttributeUsage(MulticastTargets.Method)]
    public class FluentValidationAspect : MulticastAttribute, IAspectProvider
    {
        private readonly Type _validatorType;
        private readonly string _ruleSet;
        public FluentValidationAspect(Type validatorType, string ruleSet = null)
        {
            _validatorType = validatorType;
            _ruleSet = ruleSet;
        } 
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            var entityType = _validatorType.BaseType?.GetGenericArguments()[0];
            var genericAspectType = typeof(FluentValidationAspect<>).MakeGenericType(entityType);
            yield return new AspectInstance(targetElement, new ObjectConstruction(genericAspectType, new object[] { _validatorType, _ruleSet }));
        }
    }
    [PSerializable]
    public class FluentValidationAspect<T> : IMethodLevelAspect
    {
        private Type _validatorType;
        private string _ruleSet;
        public FluentValidationAspect(Type validatorType, string ruleSet = null)
        {
            _validatorType = validatorType;
            _ruleSet = ruleSet;
        }
        public void RuntimeInitialize(MethodBase method)
        {
        }
        [SelfPointcut]
        [OnMethodEntryAdvice]
        public void OnEntry(MethodExecutionArgs args)
        {
            var entities = args.Arguments.Where(x => x is T).Select(x => (T)x);
            var validator = (IValidator<T>)Activator.CreateInstance(_validatorType);
            foreach (var entity in entities)
                ValidatorTool.FluentValidate(validator, entity);
        }
    }
