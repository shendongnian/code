    using System;
    using System.Reflection;
    
    [assembly: AssemblyVersion("1.0.*")]
    
    namespace myNameSpace
    {
      class ToBeProcessedTest
      {
        private Type tbpType = null;
        public ToBeProcessed getToBeProcessedObject(string data)
        {
          if (tbpType == null)
          {
            Assembly assembly = Assembly.LoadFrom("c:\\project\\RD_ToBeProcessed.dll");
            tbpType = assembly.GetType("myNameSpace.RD_ToBeProcessed");
          }
          Object tbp = Activator.CreateInstance(tbpType, data);
          return (ToBeProcessed)tbp;
        }
        
        public static void Main()
        {
          ToBeProcessedTest test = new ToBeProcessedTest();
          ToBeProcessed tbp1 = test.getToBeProcessedObject("myData1");
          Console.WriteLine(tbp1.Process());
          ToBeProcessed tbp2 = test.getToBeProcessedObject("myData2");
          Console.WriteLine(tbp2.Process());
          Console.ReadKey(true);
        }
      }
    }
