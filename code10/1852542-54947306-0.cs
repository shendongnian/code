    class Program
      {
        static void Main(string[] args)
        {
    
          int bmi = Calc_bmi(12, 10, 20);
          Console.WriteLine(bmi);
          Console.ReadLine();
        }
        private static int Calc_bmi(int userid, int wt, int ht)
        {
          float fWt = (float)wt;
          float fHt = (float)ht;
          float bmi = ((fWt / fHt) / fHt) * 10000;
          return Convert.ToInt32(bmi);
        }
      }
