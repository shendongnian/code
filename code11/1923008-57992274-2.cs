 c#
        // int[] source is the entire corpus
        // int[] index is the lookups into source
        // int[] results is where we want to put results
        int y = 0;
        if (Avx2.IsSupported)
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
                        rv[i] = Avx2.GatherVector256(sPtr, iv[i], 1);
                    }
                }
            }
            // move past everything we've processed via SIMD
            y += rv.Length * Vector256<int>.Count;
        }
        // now do anything left, which includes anything not aligned to 256 bits,
        // plus the "no AVX2" scenario
        int end = results.Length; // hoist, since this is not the JIT recognized pattern
        for (; y < end; y++)
        {
            results[y] = source[index[y]];
        }
