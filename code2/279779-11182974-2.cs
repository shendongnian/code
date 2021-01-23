    class Program
    {
        static int CountArray(int[] MyIntArray)
        {
            int countNum = 0;
            int[] TempIntArray = new int[MyIntArray.Length];
            for (int i = 0; i < MyIntArray.Length; i++)
            {
                TempIntArray[i] = Math.Abs(MyIntArray[i]);
            }
            var queryResults = from n in TempIntArray 
                               select n;
            countNum = queryResults.Distinct().ToArray().Length;
            return countNum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("demoX6FVFB-KX8");
            Random randomNumber = new Random();
            int[] TheArray = new int[100];
            for (int j = 0; j < TheArray.Length; j++)
			{
			    TheArray[j] = randomNumber.Next(-50, 50);
			}
            int counta = Program.CountArray(TheArray);
            Console.WriteLine(counta);
        }
    }
