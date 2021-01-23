public class Operation1 
{
    public Operation1(object data)
    { 
    }
}
public class Operation2 
{
    public Operation2(object data)
    {
    }
}
public class ActivatorsStorage
{
    public delegate object ObjectActivator(params object[] args);
    private readonly Dictionary&lt;string, ObjectActivator&gt; activators = new Dictionary&lt;string,ObjectActivator&gt;();
    private ObjectActivator CreateActivator(ConstructorInfo ctor)
    {
        Type type = ctor.DeclaringType;
        ParameterInfo[] paramsInfo = ctor.GetParameters();
        ParameterExpression param = Expression.Parameter(typeof(object[]), "args");
            
        Expression[] argsExp = new Expression[paramsInfo.Length];
        for (int i = 0; i &lt; paramsInfo.Length; i++)
        {
            Expression index = Expression.Constant(i);
            Type paramType = paramsInfo[i].ParameterType;
            Expression paramAccessorExp = Expression.ArrayIndex(param, index);
            Expression paramCastExp = Expression.Convert(paramAccessorExp, paramType);
            argsExp[i] = paramCastExp;
        }
        NewExpression newExp = Expression.New(ctor, argsExp);
            
        LambdaExpression lambda = Expression.Lambda(typeof(ObjectActivator), newExp, param);
        return (ObjectActivator)lambda.Compile();
    }
    private ObjectActivator CreateActivator(string className)
    {
        Type type = Type.GetType(className);
        if (type == null)
            throw new ArgumentException("Incorrect class name", "className");
        // Get contructor with one parameter
        ConstructorInfo ctor = type.GetConstructors()
            .SingleOrDefault(w => w.GetParameters().Length == 1 
                && w.GetParameters()[0].ParameterType == typeof(object));
        if (ctor == null)
                throw new Exception("There is no any constructor with 1 object parameter.");
        return CreateActivator(ctor);
    }
    public ObjectActivator GetActivator(string className)
    {
        ObjectActivator activator;
        if (activators.TryGetValue(className, out activator))
        {
            return activator;
        }
        activator = CreateActivator(className);
        activators[className] = activator;
        return activator;
    }
}
