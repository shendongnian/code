    public bool MyMethod(MyClass class, MyEnum enumParam)
    {
      if( (enumParam & MyEnum.A) != 0 ){
        ...
      }
      if( (enumParam & MyEnum.B) != 0 ){
        ...
      }
    }
