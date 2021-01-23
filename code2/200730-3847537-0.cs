    class MyString: IConvertible {
      
      public string Value { get; set; }
    
      ...
      object IConvertible.ToType(Type conversionType, IFormatProvider provider) {
        if (conversionType == typeof(Foo))
          return new Foo { Name = Value };
        throw new InvalidCastException();
      }
    
    }
    ...
    MyString myString = new MyString{Value="one"};
    Foo myFoo = (Foo)Convert.ChangeType(myString, typeof(Foo));
