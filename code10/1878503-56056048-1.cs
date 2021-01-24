    //using System.Linq;
    static void Main(string[] args)
    {
        int[][] matrix = new[] { new[] { 0, 1, 2, 3, 3 }, new[] { 2, 3, 4, 5 } };
        var intersection = matrix[0].Intersect(matrix[1]);
        foreach(var integer in intersection)
        {
            Console.WriteLine(integer);
        }
        Console.ReadKey();
    }
