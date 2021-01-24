 txt
AVX enabled: False; slow loop from 0
e7ad04457529f201558c8a53f639fed30d3a880f75e613afe203e80a7317d0cb
for 524288 loops: 1524ms
AVX enabled: True; slow loop from 1024
e7ad04457529f201558c8a53f639fed30d3a880f75e613afe203e80a7317d0cb
for 524288 loops: 667ms
code:
 c#
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
static class P
{
    static int Gather(int[] source, int[] index, int[] results, bool avx)
    {   // normally you wouldn't have avx as a parameter; that is just so
        // I can turn it off and on for the test; likewise the "int" return
        // here is so I can monitor (in the test) how much we did in the "old"
        // loop, vs AVX2; in real code this would be void return
        int y = 0;
        if (Avx2.IsSupported && avx)
        {
            var iv = MemoryMarshal.Cast<int, Vector256<int>>(index);
            var rv = MemoryMarshal.Cast<int, Vector256<int>>(results);
            unsafe
            {
                fixed (int* sPtr = source)
                {
                    // note: here I'm assuming we are trying to fill "results" in
                    // a single outer loop; for a double-loop, you'll probably need
                    // to slice the spans
                    for (int i = 0; i < rv.Length; i++)
                    {
                        rv[i] = Avx2.GatherVector256(sPtr, iv[i], 4);
                    }
                }
            }
            // move past everything we've processed via SIMD
            y += rv.Length * Vector256<int>.Count;
        }
        // now do anything left, which includes anything not aligned to 256 bits,
        // plus the "no AVX2" scenario
        int result = y;
        int end = results.Length; // hoist, since this is not the JIT recognized pattern
        for (; y < end; y++)
        {
            results[y] = source[index[y]];
        }
        return result;
    }
    static void Main()
    {
        // invent some random data
        var rand = new Random(12345);
        int size = 1024 * 512;
        int[] data = new int[size];
        for (int i = 0; i < data.Length; i++)
            data[i] = rand.Next(255);
        // build a fake index
        int[] index = new int[1024];
        for (int i = 0; i < index.Length; i++)
            index[i] = rand.Next(size);
        int[] results = new int[1024];
        void GatherLocal(bool avx)
        {
            // prove that we're getting the same data
            Array.Clear(results, 0, results.Length);
            int from = Gather(data, index, results, avx);
            Console.WriteLine($"AVX enabled: {avx}; slow loop from {from}");
            for (int i = 0; i < 32; i++)
            {
                Console.Write(results[i].ToString("x2"));
            }
            Console.WriteLine();
            const int TimeLoop = 1024 * 512;
            var watch = Stopwatch.StartNew();
            for (int i = 0; i < TimeLoop; i++)
                Gather(data, index, results, avx);
            watch.Stop();
            Console.WriteLine($"for {TimeLoop} loops: {watch.ElapsedMilliseconds}ms");
            Console.WriteLine();
        }
        GatherLocal(false);
        if (Avx2.IsSupported) GatherLocal(true);
    }
}
