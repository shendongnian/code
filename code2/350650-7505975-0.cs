    public void FooBar(object value, Type expected)
    {
      dynamic unboxedData = expected.FromObject(value);
      unboxedData.CallSomeMethodDefinedInTheTargetType(); // This will work.
    }
