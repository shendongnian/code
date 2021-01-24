public void InvokeMethod()
{
    var type = typeof(Modules.Achievements.Achieve);
    
    var method = type.GetMethod(methodname);
    if (method != null)
    {
        var instance = Activator.CreateInstance(type, null);
        if (instance != null)
        {
            var fixedParams = ParseParameters(method.GetParameters(), new object[] { Modules.Users.GetCreatorId() });
            if ((bool)method.Invoke(classInstance, fixedParams))
            {
                Console.WriteLine("Success");                
            }
            else
            {
                Console.WriteLine("Invalid Steam ID");
            }
            return;
        }
    }
    Console.WriteLine("Encountered an error!");
}
private object[] ParseParameters(ParameterInfo[] methodParams, object[] userParams)
{
    int mLength = methodParams.Length;
    if (mLength > 0)
    {
        var objs = new object[mLength];
        if ((userParams == null) || (userParams.Length == 0))
        {
            for (int i = 0; i < mLength; i++)
            {
                var mp = methodParams[i];
     
                objs[i] = (mp.HasDefaultValue ? mp.DefaultValue : mp.ParameterType.IsClass ? null : Activator.CreateInstance(mp.ParameterType, null));
            }
        }
        else
        {
             int uLength = userParams.Length;
             if (uLength > mLength) { throw new ArgumentException("Too many params were specified"); }
             for (int i = 0; i < uLength; i++)
             {
                 objs[i] = Convert.ChangeType(userParams[i], methodParams[i].ParameterType);
             }
             if (uLength < mLength)
             {
                 for (int i = uLength; i < mLength; i++)
                 {
                     var mp = methodParams[i];
     
                     objs[i] = (mp.HasDefaultValue ? mp.DefaultValue : mp.ParameterType.IsClass ? null : Activator.CreateInstance(mp.ParameterType, null));
                 }
             }
        }
        return objs;
    }
    return null;
}
