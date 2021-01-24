    List<string> Temp = new List<string>();
    while (true)
    {
    menu:
        string val = string.Empty;
        Console.WriteLine("[L] ägg till temp-mätning: ");
        Console.WriteLine("[S] kriv ut alla temperaturer och medeltemperatur");
        Console.WriteLine("[T] ag bort temp-mätning");
        Console.WriteLine("[A] vsluta");
        Console.Write("Selection: ");
        val = Console.ReadLine();
        switch (val.ToLower())
        {
            case "l":
            addTemperature:
                Console.WriteLine("add temperature : ");
                string temperatureInput = Console.ReadLine();
                int temperatureToAddToList;
                try
                {
                    temperatureToAddToList = Convert.ToInt32(temperatureInput); //This line trys to convert string variables to integer variables. If string variable includes any character, it will throw an exception.
                }
                catch (Exception error) //If an exception was thrown, this code block gets activated, which will give out the message you asked for.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a number instead of a string!");
                    goto addTemperature;
                }
                Temp.Add(temperatureInput.Trim());
                Console.Clear();
                break;
            case "s":
                int index = 1;
                Console.Clear();
                Console.WriteLine($"Your temperatures are: ");
                Temp.ForEach(x => Console.WriteLine($"{index++} - {x}"));
                break;
            case "t":
                if (Temp.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("There is nothing to delete, go back to menu.");
                    goto menu;
                }
                else
                {
                    Console.Write($"Which temp do you want to delete [index from 1 to {Temp.Count}]: ");
                    int deleteIndex = int.Parse(Console.ReadLine()) - 1;
                    Temp.RemoveAt(deleteIndex);
                    break;
                }
            default:
                Console.WriteLine("incorrect input: ");
                Console.Clear();
                break;
        }
