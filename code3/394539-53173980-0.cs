    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    
    namespace InformalTests
    {
    
        class Program
        {
            const int n = 100_000_000;
    
            static unsafe void Main(string[] args)
            {
                var watch = Stopwatch.StartNew();
                for (int i =0; i < n; i++)
                {
                    ThisMethodDoes_NOT_InitializeStackAllocatedMemory();
                }
                watch.Stop();
                Console.WriteLine($"NOT INITIALIZED elapsed time {watch.Elapsed}");
    
                watch.Restart();
                for (int i = 0; i < n; i++)
                {
                    ThisMethodInitializeStackAllocatedMemory();
                }
                watch.Stop();
                Console.WriteLine($"INITIALIZED Elapsed time {watch.Elapsed}");
            }
    
    
            private static unsafe string ThisMethodDoes_NOT_InitializeStackAllocatedMemory()
            {
                // avoid declaring other local vars, or doing work with stackalloc
                // to prevent the .locals init cil flag , see: https://github.com/dotnet/coreclr/issues/1279
                char* pointer = stackalloc char[256];
                return CreateString(pointer, 256);
            }
    
            private static unsafe string ThisMethodInitializeStackAllocatedMemory()
            {
                //Declaring a variable other than the stackallocated, causes
                //compiler to emit .locals int cil flag, so it's slower
                int i = 256;
                char* pointer = stackalloc char[256];
                return CreateString(pointer, i);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static unsafe string CreateString(char* pointer, int length)
            {
                return "";
            }
        }
    }
