    namespace PurushLogics
    {
        class Purush_BiggestNumber
        {
            static void Main()
            {
                int count = 0;
                Console.WriteLine("Enter Total Number of Integers\n");
                count = int.Parse(Console.ReadLine());
    
                int[] numbers = new int[count];
    
                Console.WriteLine("Enter the numbers"); // Input 44, 55, 111, 2 Output = "111"
                for (int temp = 0; temp < count; temp++)
                {
                    numbers[temp] = int.Parse(Console.ReadLine());
                }
                
                int largest = numbers[0];
                for (int big = 1; big < numbers.Length; big++)
                {
                    if (largest < numbers[big])
                    {
                        largest = numbers[big];
                    }
                }
                Console.WriteLine(largest);
                Console.ReadKey();
            }
        }
    }
