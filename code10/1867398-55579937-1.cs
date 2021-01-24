    var dict = assembly.GetTypes()
        .Where(type => !type.IsInterface)
        .Select(type => new
        {
            TypeOfRuleClass = type,
            IRuleInterface = type
                .GetGenericInterfaces().FirstOrDefault(generic => generic.IsConstructableFrom(typeof(IRule<>)))
        })
        .Where(t => t.IRuleInterface != null)
        .ToDictionary(t => t.TypeOfRuleClass, t => t.IRuleInterface.GetGenericArguments()[0]);
