    static void Main(string[] args)
    {
         Combos(new [] { 1, 2, 3 });
    }
    static void Combos(int[] arr)
    {
        for (var i = 0; i <= Math.Pow(2, arr.Length); i++)
        {
            Console.WriteLine();
            var j = i;
            var idx = 0;
            do 
            {
                if ((j & 1) == 1) Console.Write($"{arr[idx]} ");
            } while ((j >>= 1) > 0 && ++idx < arr.Length);
        }
    }
