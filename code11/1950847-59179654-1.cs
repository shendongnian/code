using System.Linq; // on top
...
for (int i = 0; i < 1; i++)
{
    for (int j = 0; j < 4; j++)
    {
        List<int> arr = new List<int>();
        for (int k = 0; k < 3; k++)
        {
            Console.WriteLine("a[{0},{1},{2}] : {3}", i, j, k, array3D[i, j, k]);
            arr.Add(array3D[i, j, k]);
        }
        Console.WriteLine($"Average of side: [{i}, {j}] = {arr.Average()}");
    }
}
