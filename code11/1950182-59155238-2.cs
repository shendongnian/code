     class Test {
        
            public static async Task Main() {
        
              var t1 = AsyncWork1();
              var t2 = AsyncWork2();
              var t3 = AsyncWork3();
        
              await Task.WhenAll(new[] { t1, t2, t3 });
    
             //all task finished but now we have to execute the result behaviour in a sync way          
    
             Console.WriteLine($"Task1 finished with value {t1.Result}");
             Console.WriteLine($"Task2 finished with value {t2.Result}");
             Console.WriteLine($"Task3 finished with value {t3.Result}");
    
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
