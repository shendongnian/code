     int param1 = 10;
     string param2 = "Hello World";
         
     try
     {
         SomeMethod(param1, param2)
     }
     catch(SomeExpectedException e)
     {
          throw new MyParameterSensitiveException(e, param1, param2);
     }
