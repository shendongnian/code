    static void Main(string[] args)
    {
        int[] Array = { 1, 7, 6, 5, 4, 3, 7, 9, 10 };
        Console.WriteLine("Array before sorting: ");
        for (int i = 0; i <= Array.Length-1 ; i++)
        {
            Console.WriteLine(Array[i] + " " );
        }
        SelectionSort(Array);
        Console.ReadLine();
    }
    public static void SelectionSort(int[] Array) // ascending order
    {
        int min;
        for (int i = 0; i <= Array.Length-1 ; i++) // go through the list
        {
            min = i; // minimum equals the current position in list
            for (int j = i+1; j < Array.Length; j++)
            {
                if (Array[j] < Array[min])
                    min = j; // min equals smallest in list j
            }
            swap(Array, i, min); // swap current position in list i and the smallest position in list j
        }
        Console.WriteLine("Array after selection sort: "); 
        for (int i = 0; i < Array.Length; i++) // display the sorted list
        {
            Console.WriteLine(Array[i] + " ");
        }
    }
    public static void swap(int[] Array,int x, int y)
    {
        int temp = Array[x];
        Array[x] = Array[y];
        Array[y] = temp;
    }
