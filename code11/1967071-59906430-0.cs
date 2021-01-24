    List<string> namn = new List<string>();
    Console.Write("Write your 5 names:\n");
    while (namn.Count != 5)
    {
        Console.Write($"Enter Name [{namn.Count + 1}/5]: ");
        namn.Add(Console.ReadLine());
    }
    while (true)
    {
        int index = 1;
        Console.Clear();
        Console.WriteLine($"Your names are: ");
        namn.ForEach(x => Console.WriteLine($"{index++} - {x}"));
        Console.WriteLine("\n\n\nWhat would you like to do: ");
        Console.WriteLine("1. Change Name");
        Console.WriteLine("2. Delete Name");
        Console.WriteLine("3. Insert Name");
        Console.WriteLine("anyKey. Exit.\n");
        Console.Write("Selection: ");
        int tal = 0;
        try { tal = int.Parse(Console.ReadLine()); } catch { continue; }
        switch (tal)
        {
            case 1:
                if (namn.Count == 0)
                {
                    Console.WriteLine("Nothing to change, insert more then change... press enter to continue");
                    Console.ReadLine();
                    break;
                }
                Console.Write($"Which name do you want to change [index from 1 to {namn.Count}]: ");
                int updateIndex = int.Parse(Console.ReadLine()) - 1;
                if (updateIndex < 0 && updateIndex > namn.Count)
                    Console.WriteLine("Nope, must be between the indecies.");
                else
                    Console.Write($"Enter New Name for [{namn[updateIndex]}]: ");
                namn[updateIndex] = Console.ReadLine();
                break;
            case 2:
                if (namn.Count == 0)
                {
                    Console.WriteLine("Nothing to delete... press enter to continue");
                    Console.ReadLine();
                    break;
                }
                Console.Write($"Which name do you want to delete [index from 1 to {namn.Count}]: ");
                int deleteIndex = int.Parse(Console.ReadLine()) - 1;
                if (deleteIndex > namn.Count() && deleteIndex < 0)
                    Console.WriteLine("Sorry, must be one of these names.");
                else
                    namn.RemoveAt(deleteIndex);
                break;
            case 3:
                Console.Write("Enter Name to insert: ");
                namn.Add(Console.ReadLine());
                break;
            case 4:
                return;
        }
    }
