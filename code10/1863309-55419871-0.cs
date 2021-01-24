    public static bool HasExpectedAuthLevel<T>(this T controller, Expression<Action<T>> action, AuthLevel expectedAuthLevel)
        where T : ApiController
    {
        return controller.HasAttributeWithExpectedArgument(action, typeof(CustomAuthorizeAttribute), expectedAuthLevel);
    }
    public static bool HasExpectedAuthLevel<T>(this T controller, Expression<Func<T, Task>> action, AuthLevel expectedAuthLevel)
        where T : ApiController
    {
        return controller.HasAttributeWithExpectedArgument(action, typeof(CustomAuthorizeAttribute), expectedAuthLevel);
    }
    public static bool HasAttributeWithExpectedArgument<TController, TArgument>(this TController controller, Expression<Action<TController>> action, Type attributeType, TArgument expectedArgument)
        where TController : ApiController
    {
        return HasAttributeWithExpectedArgument(action?.Body as MethodCallExpression, attributeType, expectedArgument);
    }
    public static bool HasAttributeWithExpectedArgument<TController, TArgument>(this TController controller, Expression<Func<TController, Task>> action, Type attributeType, TArgument expectedArgument)
        where TController : ApiController
    {
        return HasAttributeWithExpectedArgument(action?.Body as MethodCallExpression, attributeType, expectedArgument);
    }
    private static bool HasAttributeWithExpectedArgument<TArgument>(MethodCallExpression action, Type attributeType, TArgument expectedArgument)
    {
        if (action == null || !attributeType.IsSubclassOf(typeof(Attribute)))
        {
            return false;
        }
        var attributesData = action.Method.GetCustomAttributesData().Where(a => a.AttributeType == attributeType).ToArray();
        return attributesData.Any(attribute =>
            attribute.ConstructorArguments.Any(arg =>
                arg.ArgumentType == typeof(TArgument) && EqualityComparer<TArgument>.Default.Equals((TArgument)arg.Value, expectedArgument)));
    }
