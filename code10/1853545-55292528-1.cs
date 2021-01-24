    [TestMethod]
      public void TestMethod1()
      {
         try
         {
             Class1 class1 = new Class1();
             class1 = null;
             // force Garbage Collection for finalizer to run
             GC.Collect();
         }
      
         catch(Win32Exception w) 
         {
             Console.WriteLine(w.Message);
             Console.WriteLine(w.ErrorCode.ToString());
             Console.WriteLine(w.NativeErrorCode.ToString());
             Console.WriteLine(w.StackTrace);
             Console.WriteLine(w.Source);
             Exception e=w.GetBaseException();
             Console.WriteLine(e.Message);
         }
      }
