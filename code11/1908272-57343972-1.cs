    class Program
    {
        static void Main(string[] args)
        {
            //fix the 'use of undefined' error
            int average = 0;
            int[] scores = new int[10];
            Console.WriteLine("Enter 10 scores");
            //it's better to scope loop iteration variables to the loop unless you specifically need them outside 
            for (int i = 0; i < 10; i++)
            {
                scores[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < 10; i++)
            {
                //your old code would crash here, and had the wrong algorithm for calculating an average; it didn't sum all the entered values, just the last two 
                average += scores[i];
            }
            average /= 10;
            Console.WriteLine("Average of All the Scores: {0}", average);
            Console.Read();
        }
    }
