    [WebMethod]
    public Example[] GetExamples()
    {
          return new Example[]{
              new Example { Name = "Test", Value = 100 },
              new Example { Name = "Test 2", Value = 500 }
          };      
    }
