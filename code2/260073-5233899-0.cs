    int? foo = 10; // Nullable<int> with a value of 10 and HasValue = true
    int? bar = null; // Nullable<int> with a value of 0 and HasValue = false
    
    object fooObj = foo; // boxes the int 10
    object barObj = bar; // boxes null
    
    Console.WriteLine(fooObj.GetType()) // System.Int32
    Console.WriteLine(barObj.GetType()) // NullReferenceException
