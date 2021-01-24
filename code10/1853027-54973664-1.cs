csharp
using System;
using System.Runtime.InteropServices;
Boo[] boosone;
Boo[,,] boos = new Boo[8, 8, 8];
Boo GetMe(int i, int j, int k)
{
    if (boosone == null)
    {
        boosone = new Boo[boos.Length];
        MemoryMarshal.CreateSpan(ref boos[0, 0, 0], boosone.Length).CopyTo(boosone);
    }
    return boosone[boos.GetLength(0) * boos.GetLength(1) * i + boos.GetLength(1) * j + k];
}
If you don't want to use the `MemoryMarshal` class for some reason, you could also use LINQ to flatten your 3D array, although this approach is much less efficient:
csharp
boosone = boos.Cast<Boo>().ToArray();
