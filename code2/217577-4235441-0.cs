    Dictionary<int, int> values = new Dictionary<int, int>();
    ...
    Console.Write("Enter Value:", i);
    inValue = Console.ReadLine();
    i = int.Parse(inValue);
    if(values.ContainsKey(i))
    {
    	values[i]++;
    }
    else
    {
    	values.Add(i, 1);
    }
    ...
