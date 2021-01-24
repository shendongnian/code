        static void Main(string[] args)
        {
            int temp = 0, total = 0, sum = 0;
            double avg;
            string tempString;
            Console.WriteLine("Enter daily high temperatures, to stop program enter 999.");
            tempString = Console.ReadLine();
            temp = Convert.ToInt32(tempString);
            do
            {
                if (temp >= -20 && temp <= 130)
                {
                    sum += temp;
                    Console.WriteLine("Enter daily high temperatures, to stop program enter 999");
                    temp = Convert.ToInt32(Console.ReadLine());
                    total++;
                }
                else
                {
                    Console.WriteLine("Valid temperatures range from -20 to 130. Please reenter temperature.");
                    temp = Convert.ToInt32(Console.ReadLine());
                }
            } while (temp != 999);
            avg = sum / total;
            Console.WriteLine("The number of temperatures entered: {0} /n The average temperature is: {1}.", total, avg);
            Console.ReadLine();
        }
