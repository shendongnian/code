    Class1 class1 = new Class1();
    var methodsClass1 = class1.GetType().GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
    
    BaseClass baseClass = new BaseClass();
    var methodsBaseClass = baseClass.GetType().GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
    
    foreach (var t in methodsClass1.Where(z => methodsBaseClass.FirstOrDefault(y => y.Name == z.Name) == null))
    {
    	Console.WriteLine(t.Name);
    }
