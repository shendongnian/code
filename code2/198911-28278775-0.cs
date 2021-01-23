    public static string GetAttributesData(MemberInfo member)
    {            
        StringBuilder sb = new StringBuilder();
        // retrives details from all attributes of member
        var attr = member.GetCustomAttributesData();
        foreach (var a in attr)
        {
            sb.AppendFormat("Attribute Name        : {0}", a)
                .AppendLine();
            sb.AppendFormat("Constructor arguments : {0}", string.Join(",  ", a.ConstructorArguments))
                .AppendLine();
            if (a.NamedArguments != null && a.NamedArguments.Count > 0 )
            sb.AppendFormat("Named arguments       : {0}", string.Join(",  ", a.NamedArguments))
                .AppendLine();
            sb.AppendLine();
        }            
        return sb.ToString();
    }
