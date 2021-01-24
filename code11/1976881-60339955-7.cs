    namespace program {
      class Program {
        private static float ReadSingle(string title = null) {      
          while (true) {
            if (!string.IsNullOrWhiteSpace(title))
              Console.WriteLine(title);
    
            if (float.TryParse(Console.ReadLine(), out float result))
              return result;
    
            Console.WriteLine("Invalid format, please try again.");  
          }
        }
    
        static void Main(string[] args) {
         float[] aa = new float[] {
            ReadSingle(),  
            ReadSingle(),
            ReadSingle(), 
          };
    
          float[] bb = new float[] {
            ReadSingle(),  
            ReadSingle(),
            ReadSingle(), 
          };
    
          Array.Sort(aa);
          Array.Sort(bb); 
    
          Console.WriteLine((aa[0]- aa[1]) * (bb[0] - bb[1]) / 2);
        }
      }
    }
