    static void Main(string[] args)
    {
        uint n = uint.Parse(Console.ReadLine());
        uint m = uint.Parse(Console.ReadLine());
        int[,] array=new int [n,m];
        FillArrayMethodC(array, n, m); // pass array into "fill" method
    }
        
    static void FillArrayMethodC(int[,] a, uint n, uint m)
    {
        //fill the array
        ...
        // nothing to return
    }
