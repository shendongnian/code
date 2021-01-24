    public void SomeMethod()
    {
      using ( DisposableObject disposableObject = new DisposableObject() )
      {
        // Do some stuff with the object
        SomeOtherMethod(disposableObject);
      }
    }
