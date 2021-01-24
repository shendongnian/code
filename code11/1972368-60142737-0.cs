    static void Main(string[] args)
    {
        // create an array named as n of 10 integers
        int[] n = new int[10];
        // create a for loop to assign the value to the n array from 100 to 109.
        for (int i= 0; i < 10; i++)
        {
            n[i] = 100 + i;
        }
        // create a foreach loop to output each array element's value.
        foreach (int item in n)
        {
            Console.WriteLine(item);
        }
    }
