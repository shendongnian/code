    public abstract class RuleChain<TContext> : IRuleChain<TContext> {
        private readonly Stack<Func<RuleHandlingDelegate<TContext>, RuleHandlingDelegate<TContext>>> components =
            new Stack<Func<RuleHandlingDelegate<TContext>, RuleHandlingDelegate<TContext>>>();
        private bool built = false;
        public RuleHandlingDelegate<TContext> Build() {
            if (built) throw new InvalidOperationException("Chain can only be built once");
            var next = new RuleHandlingDelegate<TContext>(context => Task.CompletedTask);
            while (components.Any()) {
                var component = components.Pop();
                next = component(next);
            }
            built = true;
            return next;
        }
        public IRuleChain<TContext> Use<TRule>() {
            components.Push(createDelegate<TRule>);
            return this;
        }
        protected abstract object GetService(Type type, params object[] args);
        private RuleHandlingDelegate<TContext> createDelegate<TRule>(RuleHandlingDelegate<TContext> next) {
            var ruleType = typeof(TRule);
            MethodInfo methodInfo = getValidInvokeMethodInfo(ruleType);
            //Constructor parameters
            object[] constructorArguments = new object[] { next };
            object[] dependencies = getDependencies(ruleType, GetService);
            if (dependencies.Any())
                constructorArguments = constructorArguments.Concat(dependencies).ToArray();
            //Create the rule instance using the constructor arguments (including dependencies)
            object rule = GetService(ruleType, constructorArguments);
            //return the delegate for the rule
            return (RuleHandlingDelegate<TContext>)methodInfo
                .CreateDelegate(typeof(RuleHandlingDelegate<TContext>), rule);
        }
        private MethodInfo getValidInvokeMethodInfo(Type type) {
            //Must have public method named Invoke or InvokeAsync.
            var methodInfo = type.GetMethod("Invoke") ?? type.GetMethod("InvokeAsync");
            if (methodInfo == null)
                throw new InvalidOperationException("Missing invoke method");
            //This method must: Return a Task.
            if (!typeof(Task).IsAssignableFrom(methodInfo.ReturnType))
                throw new InvalidOperationException("invalid invoke return type");
            //and accept a first parameter of type TContext.
            ParameterInfo[] parameters = methodInfo.GetParameters();
            if (parameters.Length != 1 || parameters[0].ParameterType != typeof(TContext))
                throw new InvalidOperationException("invalid invoke parameter type");
            return methodInfo;
        }
        private object[] getDependencies(Type middlewareType, Func<Type, object[], object> factory) {
            var constructors = middlewareType.GetConstructors().Where(c => c.IsPublic).ToArray();
            var constructor = constructors.Length == 1 ? constructors[0]
                : constructors.OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();
            if (constructor != null) {
                var ctorArgsTypes = constructor.GetParameters().Select(p => p.ParameterType).ToArray();
                return ctorArgsTypes
                    .Skip(1) //Skipping first argument since it is suppose to be next delegate
                    .Select(parameter => factory(parameter, null)) //resolve other parameters
                    .ToArray();
            }
            return Array.Empty<object>();
        }
    }
