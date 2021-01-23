    using System;
    namespace Assignment7
    {
        class Plane
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Welcome to the Airline Reservation System.");
                Console.WriteLine("Where would you like to sit?\n");
                Console.WriteLine("Enter 1 for First Class.");
                Console.WriteLine("Enter 2 for Economy.");
                CheckIn(0, 0);
            }
    
            public static void CheckIn(int firstClassSeatsTaken, int economySeatsTaken)
            {
                int choice = Convert.ToInt32(Console.ReadLine());
    
                if (choice == 1)
                {
                    do
                    {
                        Console.WriteLine("You have chosen a First Class seat.");
                        firstClass++;
                        CheckIn(firstClassSeatsTaken, economySeatsTaken);
                    } while (firstClass < 5);
                }
                else if (choice == 2)
                {
                    do
                    {
                        Console.WriteLine("You have chosen an Economy seat.");
                        economy++;
                        CheckIn(firstClassSeatsTaken, economySeatsTaken);
                    } while (economy < 5);
                }
                else
                {
                    Console.WriteLine("That does not compute.");
                    CheckIn(firstClassSeatsTaken, economySeatsTaken);
                }
            }
        }
    }
