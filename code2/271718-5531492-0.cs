    Add-Type -Language CSharpVersion3 -TypeDefinition @"
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
    "@
    
    $method   = [Class2].GetMethod("Callback") 
    $delegate = [System.Delegate]::CreateDelegate([System.Action[Object]], $null, $method)
    
    [Class1]::MyMethod($delegate)
