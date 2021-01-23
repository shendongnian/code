    var valueA = (IComparable)objA.GetType().GetProperty("MyProperty").GetValue(objA, null);
    var valueB = (IComparable)objB.GetType().GetProperty("MyProperty").GetValue(objB, null);
    if (valueA.CompareTo(valueB) > 0) {
        // ...            
    }
