    Action<Customer1, Customer2> baseMap = (c1, c2) => c2.FirstName = c1.FirstName;
    var list = new List<object>()
    {
        (Action<SpecialCustomer1, 
                SpecialCustomer2>)(new ModifiedClosure(baseMap).Method),
        // ...
    };
