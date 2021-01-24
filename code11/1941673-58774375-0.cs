c#
using System;
using System.Reflection;
public class C
{
    public void TypeDetector(ParameterInfo p)
    {
        if (ReferenceEquals(p.ParameterType, typeof(int)))
        {
        }
        else if (ReferenceEquals(p.ParameterType, typeof(string)))
        {
        }
        else
        {
        }
    }
                 
    public void TypeDetector_SwitchStatement(ParameterInfo p)
    {
        // C# 7
        switch (p.ParameterType)
        {
            case Type t when ReferenceEquals(t, typeof(int)):
                break;
            case Type t when ReferenceEquals(t, typeof(string)):
                break;
            default:
                break;
        }
    }
                 
    public string TypeDetector_SwitchExpression(ParameterInfo p)
    {
        // C# 8
        return p.ParameterType switch
        {
            Type t when ReferenceEquals(t, typeof(int)) => "int",
            Type t when ReferenceEquals(t, typeof(string)) => "string",
            _ => "Something else"
        };
    }
}
