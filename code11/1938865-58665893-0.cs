public static void Main(string[] args)
{
    int n = 10; //10 values in array
    Random r = new Random();
    int[] a = new int[n]; //array
    for (int i = 0; i < a.Length; i++) // set the array up
        a[i] = r.Next(1, 100); // + random numbers 
    foreach(int x in a)
        Console.WriteLine(x + " "); // outputs the numbers of array
    Console.WriteLine();
    Console.ReadLine();
    for (int i = 0; i < a.Length - 1; i++) 
    {
        for (int j = 0; j < a.Length - 1; j++) 
        {
            if (a[j] > a[j + 1])
            {
                int temp = a[j + 1]; //stores temporarily
                a[j + 1] = a[j];
                a[j] = temp;
            }
        }
    }
    Console.WriteLine("Array is sorted: ");
    foreach (int number in a) 
      Console.Write(number + " ");
    Console.Read();
}
