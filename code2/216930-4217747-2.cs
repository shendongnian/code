      static void Main(string[] args)
      {
         try
         {
            Rethrower();
         }
         catch (Exception ex)
         {
            Console.Write(ex.ToString());
         }
         Console.ReadKey();
      }
      static void Rethrower()
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
      static void Foo()
      {
         throw new Exception("Test"); 
      }
