    [ExpectedException(typeof(MyException))]
    void my_test()
    {
         try
         {
             // call the service
         }
         catch(MyException ex)
         {
              Assert.IsTrue(ex.Message.Contains("error code 200"));
              throw ex;
         }
         
    }
