        static void Main(string[] args, int answer)
        {  // <- now sum scope begins here
            ...
            int sum = 0;
            for (i = 0; i < number; i++)
            {
                if (i % 4 == 0 || i % 6 == 0)
                {
                    //DONE: you probably want to add i to sum, not to total
                    sum = sum + i;
                }
                Console.WriteLine(sum);
            }
        }  // <- sum scope ends here
