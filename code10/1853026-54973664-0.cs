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
    return boosone[boos.GetLength(0) * i + boos.GetLength(1) * j + k];
}
