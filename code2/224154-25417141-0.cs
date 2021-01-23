    class Program
    {
        public static void Main()
        {
            
            float large, small;
            int[] a = new int[50];
            Console.WriteLine("Enter the size of Array");
            int max = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the array elements");
            for (int i = 0; i < max; i++)
            {
                string s1 = Console.ReadLine();
                a[i] = Int32.Parse(s1);
            }
            Console.Write("");
            large = a[0];
            small = a[0];
            for (int i = 1; i < max; i++)
            {
                if (a[i] > large)
                    large = a[i];
                else if (a[i] < small)
                    small = a[i];
            }
            Console.WriteLine("Largest element in the array is {0}", large);
            Console.WriteLine("Smallest element in the array is {0}", small);
        }
    }
