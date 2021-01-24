      public class Program {
        public static void Main()
        {
          double[,] disQC = new double[5, 5];
          List<List<double>> lQC = new List<List<double>>();
          for (int j = 0; j < 5; j++) {
            lQC.Add(new List<double>());
            for (int i = 0; i < 5; i++) {
              if (i % 2 == 0){
                disQC[i, j] =i + 1 ;
              }
              else{
                disQC[i, j] = j + 1;
              }
              lQC[j].Add(disQC[i, j]);
            }
                   
          }
          lQC.ForEach(l => { l.ForEach(t => Console.Write(t)); Console.WriteLine(""); });
        }
      }
