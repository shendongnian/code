using System.Linq; // on top
using System.Collections.Generic;
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
        Console.WriteLine($"Average of side: [{i}, {j}] = {(int)arr.Average()}");
    }
}
and the output you get is:
a[0,0,0] : 4
a[0,0,1] : 5
a[0,0,2] : 6
Average of side: [0, 0] = 5
a[0,1,0] : 4
a[0,1,1] : 4
a[0,1,2] : 5
Average of side: [0, 1] = 4
a[0,2,0] : 3
a[0,2,1] : 6
a[0,2,2] : 4
Average of side: [0, 2] = 4
a[0,3,0] : 5
a[0,3,1] : 4
a[0,3,2] : 5
Average of side: [0, 3] = 4
