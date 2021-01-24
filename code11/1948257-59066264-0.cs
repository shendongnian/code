            string n = "mynewstring";
            string m = "myNewString";
            foreach (char c in n)
            {
                Console.Write(((int)c).ToString(("X")));
                Console.Write("-");
            }
            Console.WriteLine();
            foreach (char c in m)
            {
                Console.Write(((int)c).ToString(("X")));
                Console.Write("-");
            }
            Console.WriteLine();
