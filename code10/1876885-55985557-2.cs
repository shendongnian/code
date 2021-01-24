    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    
    namespace RadixSort
    {
        class Program
        {
    
            static void RadixSort(uint [] a, uint count)
            {
            uint [,] mIndex = new uint [4,256];     // count / index matrix
            uint [] b = new uint [count];           // allocate temp array
            uint i,j,m,n;
            uint u;
                for(i = 0; i < count; i++){         // generate histograms
                    u = a[i];
                    for(j = 0; j < 4; j++){
                        mIndex[j,(u & 0xff)]++;
                        u >>= 8;
                    }       
                }
                for(j = 0; j < 4; j++){             // convert to indices
                    m = 0;
                    for(i = 0; i < 256; i++){
                        n = mIndex[j,i];
                        mIndex[j,i] = m;
                        m += n;
                    }       
                }
                for(j = 0; j < 4; j++){             // radix sort
                    for(i = 0; i < count; i++){     //  sort by current lsb
                        u = a[i];
                        m = (u>>((int)(j<<3)))&0xff;
                        b[mIndex[j,m]++] = u;
                    }
                    uint [] t = a;                  //  swap references
                    a = b;
                    b = t;
                }
            }
    
            static void Main(string[] args)
            {
                const int SIZE = 500000;
                uint [] a = new uint[SIZE];
                uint u;
                Random r = new Random(1);
                Stopwatch sw = new Stopwatch();
                for (uint i = 0; i < a.Length; i++)
                {
                    u = (uint)r.Next(1 << 16);
                    u = (u << 16) | (uint)r.Next(1 << 16);
                    a[i] = u;
                }
                sw.Start();
                RadixSort(a, (uint)a.Length);
                sw.Stop();
                for (uint i = 1; i < a.Length; i++)
                {
                    if(a[i] < a[i-1])
                    {
                        Console.WriteLine("failed");
                        break;
                    }
                }
                Console.WriteLine("milliseconds: {0:D}\n",sw.ElapsedMilliseconds);
            }
        }
    }
