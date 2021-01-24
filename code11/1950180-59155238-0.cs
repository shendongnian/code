    class Test {
    
        public static async Task Main() {
    
          var t1 = AsyncWork1().ContinueWith((t) => Console.WriteLine($"Task1 finished with value {t.Result}"));
          var t2 = AsyncWork2().ContinueWith((t) => Console.WriteLine($"Task2 finished with value {t.Result}"));
          var t3 = AsyncWork3().ContinueWith((t) => Console.WriteLine($"Task3 finished with value {t.Result}"));
    
          await Task.WhenAll(new[] { t1, t2, t3 });
          //here we will now that all tasks has been finished and its result behaviour executed.
          Console.ReadKey();    
        }//main
    
        public static async Task<int> AsyncWork1() {
          await Task.Delay(1000);
          return 1;
        }
    
        public static async Task<string> AsyncWork2() {
         await Task.Delay(100);
          return "work2";
        }
    
        public static async Task<bool> AsyncWork3() {
          await Task.Delay(500);
          return true;
        }
    
      }//class Test
