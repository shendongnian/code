    Console.Write("Enter size of array");
    int n = Convert.ToInt16(Console.ReadLine());
    int[] dynamicSizedArray= new int[n]; // Here we have created an array of size n
    Console.WriteLine("Input Elements");
    for(int i=0;i<n;i++)
    {
         dynamicSizedArray[i] = Convert.ToInt32(Console.ReadLine());
    }
    Console.WriteLine("Elements of array are :");
    foreach (int i in dynamicSizedArray)
    {
        Console.WriteLine(i);
    }
    Console.ReadKey();
