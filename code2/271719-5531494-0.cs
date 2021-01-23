    $code = @'
    using System;
    public class Class1
    {    
        public static void MyMethod(Action<object> obj)    
        {
            obj("Hey!");    
        }
    }
    public class Class2
    {    
        public static void Callback(object obj)    
        {         
            Console.WriteLine(obj.ToString());    
        }
    }
    '@
    
    Add-Type -TypeDefinition $code -Language CSharpVersion3
    [class1]::mymethod([system.action]::CreateDelegate('System.Action[Object]', [class2].getmethod('Callback')))
