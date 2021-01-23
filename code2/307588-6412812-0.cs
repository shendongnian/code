    /// <summary>
    /// Choose the constructor to call for the given type.
    /// </summary>
    /// <param name="context">Current build context</param>
    /// <param name="resolverPolicyDestination">The <see cref='IPolicyList'/> to add any
    /// generated resolver objects into.</param>
    /// <returns>The chosen constructor.</returns>
    public SelectedConstructor SelectConstructor(IBuilderContext context, IPolicyList resolverPolicyDestination)
    {
        Type typeToConstruct = context.BuildKey.Type;
        ConstructorInfo ctor = FindInjectionConstructor(typeToConstruct) ?? FindLongestConstructor(typeToConstruct);
        if (ctor != null)
        {
            return CreateSelectedConstructor(context, resolverPolicyDestination, ctor);
        }
        return null;
    }
