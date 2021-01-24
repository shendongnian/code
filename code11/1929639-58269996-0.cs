     public static void Logic()
        {
            bool exit = false;
            do
            {
                var info = Console.ReadLine().Split();
                switch (info[0])
                {
                    case "END":
                        exit = true;
                        break;
                }
            }
            while (!exit);
        }
