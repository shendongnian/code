    namespace PurushLogics
    {
        class Purush_SmallesNumber
        {
            static void Main()
            {
                int count = 0;
                Console.WriteLine("Enter Total Number of Integers\n");
                count = int.Parse(Console.ReadLine());
    
                int[] numbers = new int[count];
    
                Console.WriteLine("Enter the numbers"); // Input 44, 55, 111, 2 Output = "2"
                for (int temp = 0; temp < count; temp++)
                {
                    numbers[temp] = int.Parse(Console.ReadLine());
                }
    
                int smallest = numbers[0];
                for (int small = 1; small < numbers.Length; small++)
                {
                    if (smallest > numbers[small])
                    {
                        smallest = numbers[small];
                    }
                }
                Console.WriteLine("Smallest Number is : \"{0}\"",smallest);
                Console.ReadKey();
            }
        }
    }
