    private object GetIEnumerableRequest(Type type)
    {
        var genericResolveAllMethod = this.GetType().GetGenericMethod(BindingFlags.Public | BindingFlags.Instance, "ResolveAll", type.GetGenericArguments(), new[] { typeof(bool) });
        return genericResolveAllMethod.Invoke(this, new object[] { false });
    }
