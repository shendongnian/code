Basic: 2313122, 58ms
Vectorized: 2313122, 18ms
code:
 c#
using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
static class Program
{
    static void Main()
    {
        int len = 200;
        byte[] hash1 = new byte[len];
        byte[] hash2 = new byte[len];
        var rand = new Random(123456);
        rand.NextBytes(hash1);
        rand.NextBytes(hash2);
        Run(nameof(Basic), Basic, hash1, hash2);
        Run(nameof(Vectorized), Vectorized, hash1, hash2);
    }
    static void Run(string caption, Func<byte[], byte[], int> func, byte[] x, byte[] y, int repeat = 500000)
    {
        var timer = Stopwatch.StartNew();
        int result = 0;
        for (int i = 0; i < repeat; i++)
        {
            result = func(x, y);
        }
        timer.Stop();
        Console.WriteLine($"{caption}: {result}, {timer.ElapsedMilliseconds}ms");
    }
    static int Basic(byte[] hash1, byte[] hash2)
    {
        int distanceSquared = 0;
        for (int i = 0; i < hash1.Length; i++)
        {
            var diff = hash1[i] - hash2[i];
            distanceSquared += diff * diff;
        }
        return distanceSquared;
    }
    static int Vectorized(byte[] hash1, byte[] hash2)
    {
        int start, distanceSquared;
        if (Vector.IsHardwareAccelerated)
        {
            var sum = Vector<int>.Zero;
            var vec1 = MemoryMarshal.Cast<byte, Vector<byte>>(hash1);
            var vec2 = MemoryMarshal.Cast<byte, Vector<byte>>(hash2);
            
            for (int i = 0; i < vec1.Length; i++)
            {
                // widen and hard cast needed here to avoid overflow problems
                Vector.Widen(vec1[i], out var l1, out var r1);
                Vector.Widen(vec2[i], out var l2, out var r2);
                Vector<short> lt1 = Vector.AsVectorInt16(l1), rt1 = Vector.AsVectorInt16(r1);
                Vector<short> lt2 = Vector.AsVectorInt16(l2), rt2 = Vector.AsVectorInt16(r2);
                Vector.Widen(lt1 - lt2, out var dl1, out var dl2);
                Vector.Widen(rt1 - rt2, out var dr1, out var dr2);
                sum += (dl1 * dl1) + (dl2 * dl2) + (dr1 * dr1) + (dr2 * dr2);
            }
            start = vec1.Length * Vector<byte>.Count;
            distanceSquared = 0;
            for (int i = 0; i < Vector<int>.Count; i++)
                distanceSquared += sum[i];
        }
        else
        {
            start = distanceSquared = 0;
        }
        for (int i = start; i < hash1.Length; i++)
        {
            var diff = hash1[i] - hash2[i];
            distanceSquared += diff * diff;
        }
        return distanceSquared;
    }
}
