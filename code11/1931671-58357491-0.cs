    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        public class User
        {
            public string name;
            public string password;
            public string notepad;
        }
        class Program
        {
            static void Main(string[] args)
            {
                // I've added this line to get around the missing login source
                bool login = true;
                Console.Clear();
                Console.WriteLine("\n--------------------------\n" + "Please create a new user." + "\n--------------------------");
                Console.WriteLine("\nUsername: ");
                string x = Console.ReadLine();
                Console.WriteLine("\nPassword: ");
                string y = Console.ReadLine();
                User xe = new User();
                xe.name = x;
                //----removed cuz has nothing to do with the code----
                Console.WriteLine("Dashboard");
                Console.WriteLine("\nPlease choose a function by inputting the number before the name.\n1 - Notepad\n2 - Calculator");
                while (login)
                {
                    try
                    {
                        // Here I've separated the input request, the combination of the convertion and the input mixed kept crashing.
                        string theletter = Console.ReadLine();
                        int letter = Convert.ToInt32(theletter);
                        login = false;
                        if (letter == 1)
                        {
                            Console.WriteLine("Notepad");
                            // Here I'm calling the notepad method with the xe
                            notepad(xe);
                            Console.WriteLine("\n\n* Ok, I'm back in the Main *\n");
                            Console.ReadLine();
                        }
                        else if (letter == 2)
                        {
                            Console.WriteLine("Calculator");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please input a number.");
                    }
                }
            }
            // **** Here I've changed the return type from string to void, since it's not returning anything.
            // **** I've also added a parameter to pass the xe as xel (optional) using the proper type
            public static void notepad(User xel)
            {
                Console.WriteLine("\n\n * I'm here in the notepad method *\n");
                string np = Console.ReadLine();
                xel.notepad = np;
                Console.WriteLine("\nYou entered this for your notepad: \n");
                Console.WriteLine(np.ToString());
                Console.WriteLine("\nThis is your new notepad: \n");
                Console.WriteLine(xel.notepad.ToString());
            }
        }
    }
