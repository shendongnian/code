    void Main()
    {
        Type type = typeof(TestClass<>);
        foreach (var parm in type.GetGenericArguments())
        {
            Debug.WriteLine(parm.Name);
            parm.GetGenericParameterConstraints().Dump();
            parm.GenericParameterAttributes.Dump();
        }
    }
    
    public class TestClass<T>
        where T : new()
    {
    }
