        class Program
    {
        unsafe
        static void Main(string[] args)
        {
            int arraySize = 100;
            int iterations = 10000000;
            ms[] msa = new ms[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                msa[i].d1 = i + .1d;
                msa[i].d2 = i + .2d;
                msa[i].d3 = i + .3d;
                msa[i].d4 = i + .4d;
                msa[i].d5 = i + .5d;
                msa[i].d6 = i + .6d;
                msa[i].d7 = i + .7d;
            }
           
            int sizeOfms = Marshal.SizeOf(typeof(ms));
            byte[] bytes = new byte[arraySize * sizeOfms];
             
            TestPerf(arraySize, iterations, msa, sizeOfms, bytes);
            // lets round trip it.
            var msa2 = new ms[arraySize]; // Array of structs we want to push the bytes into
            var handle2 = GCHandle.Alloc(msa2, GCHandleType.Pinned);// get handle to that array
            Marshal.Copy(bytes, 0, handle2.AddrOfPinnedObject(), bytes.Length);// do the copy
            handle2.Free();// cleanup the handle
            // assert that we didnt lose any data.
            var passed = true;
            for (int i = 0; i < arraySize; i++)
            {
                if(msa[i].d1 != msa2[i].d1
                    ||msa[i].d1 != msa2[i].d1
                    ||msa[i].d1 != msa2[i].d1
                    ||msa[i].d1 != msa2[i].d1
                    ||msa[i].d1 != msa2[i].d1
                    ||msa[i].d1 != msa2[i].d1
                    ||msa[i].d1 != msa2[i].d1)
                {passed = false;
                break;
                }
            }
            Console.WriteLine("Round trip {0}",passed?"passed":"failed");
        }
        unsafe private static void TestPerf(int arraySize, int iterations, ms[] msa, int sizeOfms, byte[] bytes)
        {
            // start benchmark.
            var sw = Stopwatch.StartNew();
            // this cheats a little bit and reuses the same buffer 
            // for each thread, which would not work IRL
            var plr = Parallel.For(0, iterations/1000, i => // Just to be nice to the task pool, chunk tasks into 1000s
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        // get a handle to the struc[] we want to copy from
                        var handle = GCHandle.Alloc(msa, GCHandleType.Pinned);
                        Marshal.Copy(handle.AddrOfPinnedObject(), bytes, 0, bytes.Length);// Copy from it
                        handle.Free();// clean up the handle
                        // Here you would want to write to some buffer or something :)
                    }
                });
            // Stop benchmark
            sw.Stop();
            var size = arraySize * sizeOfms * (double)iterations / 1024 / 1024 / 1024d; // convert to GB from Bytes
            Console.WriteLine("Finished in {0}ms, Processed {1:N} GB", sw.ElapsedMilliseconds, size);
            Console.WriteLine("For data write rate of {0:N} GB/s", size / (sw.ElapsedMilliseconds / 1000d));
        }
    }
    [StructLayout(LayoutKind.Explicit, Size= 56, Pack=1)]
    struct ms
    {
        [FieldOffset(0)]
        public double d1;
        [FieldOffset(8)]
        public double d2;
        [FieldOffset(16)]
        public double d3;
        [FieldOffset(24)]
        public double d4;
        [FieldOffset(32)]
        public double d5;
        [FieldOffset(40)]
        public double d6;
        [FieldOffset(48)]
        public double d7;
    }
