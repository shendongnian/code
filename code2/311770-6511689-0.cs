    var c = new MyClass();
    myObject.MyMethod(c);
    ...
    void MyMethod(IPropertySetter setter) {
      setter.Property = someValue;
      // you can also store the "setter" and use it later...
    }
