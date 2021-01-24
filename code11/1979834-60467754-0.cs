    class Program
    {
      public static double avg(int[] arr)
      {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum / arr.Length;
    }
    public static void Main(string[] args)
    {
        int SIZE = 4;
        string[] names = new string[SIZE];
        int[] score = new int[SIZE];
        double avg1 = 0;
        for (int i = 0; i < SIZE; i++)
        {
            Console.Write("Enter a score between 1 - 100.  ");
            score[i] = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if (!(score[i] >= 1 && score[i] <= 100))
                {
                    Console.WriteLine("Invalid number entered.");
                    score[i] = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            
        }
        avg1 = avg(score);
        Console.WriteLine("The average of the test scores is: " + Math.Round(avg1, 2));
    }
