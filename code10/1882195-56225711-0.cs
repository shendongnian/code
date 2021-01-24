    List<int[]> matrix = new List<int[]>();
    
    for (int i = 0; i < rows; i++)
    { 
        int[] numbers = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        matrix.Add(numbers);    //to add the elements here
    }
    
    int sum = 0;
    foreach (var element in matrix.SelectMany(array => array))
    {
        sum += element;
    }
