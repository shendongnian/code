    var r = new Record();
    
    // r.Id is null by default, but we can still call HasValue()
    // because extension methods work on null references.
    r.Id.HasValue(); // => false
    
    // We can explicitly set Id to null.
    r.Id = null;
    // We can set Id to a primitive numeric value directly
    // thanks to our implicit conversion operators.
    r.Id = 1;
    
    // We can also use NullableInt32 in any context that expects a
    // Nullable<int>. The signature of the following method is
    // bool Equals(int?, int?).
    Nullable.Equals<int>(r.Id, 1); // => true
    
    // We can explicitly set Id to a NullableInt32.
    r.Id = new NullableInt32 { Value = 1 };
    // Just like Nullable<int>, we can get or set the Value of a
    // NullableInt32 directly, but only if it's not null. Otherwise,
    // we'll get a NullReferenceException. Use HasValue() to avoid this.
    if(r.Id.HasValue())
      r.Id.Value.ToString(); // => "1"
    // Setting Id to 0 is the same as setting Id to a new
    // NullableInt32 since the default value of int32 is 0.
    // The following expressions are equivalent.
    r.Id = 0;
    r.Id = new NullableInt32();
    r.Id = new NullableInt32 { Value = 0 };
    r.Id.Value = 0; // as long as Id is not null
