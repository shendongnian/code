    static int[] fillArray()
    {
        List<int> list = new List<int>();
        do
        {
            Console.Write("Please enter a number to add to the array or \"x\" to stop: ");
            string consoleInput = Console.ReadLine();
            if (consoleInput == "x")
            {
                return list.ToArray();
            }
            else
            {
                list.Add(Convert.ToInt32(consoleInput));
            }
        } while (count < 8);
        return list.ToArray();
    }
