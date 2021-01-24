    class Program
    {
        static int[] nums; 
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            int[] nums = new int[counter];
            while (counter > 0)
            {
                nums[counter] = counter;
                counter--;
            }
            print(counter);
        }
        public static void print(int count)
        {
            // some code
            while (count > 0)
            {
                Console.WriteLine(nums[count]); //line with the error
                count--;
            }
        }
    }
