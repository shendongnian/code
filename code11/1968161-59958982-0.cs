    List<string> Temp = new List<string>();
    while (true)
    {
        string val;
        Console.WriteLine("[L] ägg till temp-mätning: ");
        Console.WriteLine("[S] kriv ut alla temperaturer och medeltemperatur");
        Console.WriteLine("[T] ag bort temp-mätning");
        Console.WriteLine("[A] vsluta");
        Console.Write("Selection: ");
        val = Console.ReadLine();
		switch (val.ToLower())
		{
			case "l":
				Console.WriteLine("add temperature : ");
				Temp.Add(Console.ReadLine());
				Console.Clear();
				break;
			case "s":
				int index = 1;
				Console.Clear();
				Console.WriteLine($"Your temperatures are: ");
				Temp.ForEach(x => Console.WriteLine($"{index++} - {x}"));
				break;
			case "t":
				Console.Write($"Which temp do you want to delete [index from 1 to {Temp.Count}]: ");
				int deleteIndex = int.Parse(Console.ReadLine()) - 1;
				Temp.RemoveAt(deleteIndex);
				break;
			default:
				Console.WriteLine("incorrect input: ");
				Console.Clear();
				break;
		}
