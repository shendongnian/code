    void MyClass::Foo()
    {
    
    {
      SqlConnection connection(connectionString);
      //connection still allocated on the managed heap
      connection.Open();
      ...
      //connection will be automatically disposed 
      //when the object gets out of scope
    } 
    
    
    {
      SqlConnection connection(connectionString2);
      connection2.Open();
      ...
    }
    
    }
