    static void CheckDynamic(MemberInfo memberInfo)
    {
        bool isDynamic = memberInfo.GetCustomAttributes(typeof(DynamicAttribute), true).Length > 0;
    
        var methodInfo = (memberInfo as MethodInfo);
        if (methodInfo != null)
        {
            isDynamic = methodInfo.ReturnTypeCustomAttributes.GetCustomAttributes(typeof(DynamicAttribute), true).Length > 0;
        }
    
        Console.WriteLine(memberInfo.Name + (isDynamic ? " is dynamic" : " is NOT dynamic!!"));
    }
