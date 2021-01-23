            int[] bottles = new int[4];
            while (true)
            {
                Console.Write("Enter the room you're in: ");
                string inputString = Console.ReadLine();
                if (inputString == "quit")
                    break;
                int room = int.Parse(inputString);
                Console.Write("Bottles collected in room {0}: ", room);
                bottles[room - 1] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < bottles.Length; ++i)
                Console.WriteLine("Bottles collected in room {0} = {1}", i + 1, bottles[i]);
