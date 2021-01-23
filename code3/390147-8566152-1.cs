    using System.Reflection;
    
    class MyClass{
        var Var1;
        var Var2;
        ...
        var infos = typeof(MyClass).GetFields();
        foreach(var info in infos)
        {
            if(info.GetValue(this)==null) ShowErrorMessage(info.Name);
        }
    }
