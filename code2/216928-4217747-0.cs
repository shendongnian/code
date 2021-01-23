      static void Main(string[] args)
      {
         try
         {
            try
            {
               Foo();
            }
            catch (Exception ex)
            {
               throw;
            }
         }
         catch (Exception ex)
         {
            // prints that the exception comes from `Foo()` 
            Console.Write(ex.ToString());
         }
      }
      static void Foo()
      {
         throw new Exception("Test"); 
      }
