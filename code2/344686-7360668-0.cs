    public static void UseParams(params int[] list) 
        {
            for (int i = 0 ; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine();
        }
