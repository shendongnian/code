    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            for(int i = 0; i < 1000; i++)
            {
                list.Add(i);
            }
            int[] arr = new int[1000];
            arr = list.ToArray();
            // Start from 0 and increment parameters by 1 until the end
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] % 5 == 0)
                {
                    Console.WriteLine(arr[i]);
                }
            }
        }
    }
