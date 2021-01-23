        namespace MyNs
        {
          public class MyClass
          {
         [ThreadStatic] // thread static so the data is specific to the calling thread
         public static string MyEnumerableVariable;
    
         public void DoSomething() 
         {
              Evaluator.ReferenceAssembly(Assembly.GetExecutingAssembly());
              Evaluator.Run("using MyNs;")
              // run the dynamic code
              var s = @"return (from contact in MyNs.MyClass.MyEnumerableVariable where contact.Name == ""John"" select contact).ToList();";
              Evaluator.Evaluate(s);
         }
      }
    }
