    public bool MyMethod(MyClass class, MyEnum enumParam)
    {
      if( enumParam & MyEnum.A ){
        ...
      }
      if( enumParam & MyEnum.B ){
        ...
      }
    }
