    int[] array1 = { 0, 6, 7, 8, 5 };
    Console.Write("Enter the Index: ");
    int.TryParse(Console.ReadLine(), out int index);
    if (index < array1.Length)
        Console.WriteLine(array1[index]);
