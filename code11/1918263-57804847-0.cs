    using Hybridizer.Runtime.CUDAImports;
    using System;
    using System.Threading.Tasks;
    
    namespace HybridizerSample
    {
        class Program
        {
            [EntryPoint]
            public static void Run(int N, IntResidentArray a, IntResidentArray b, IntResidentArray c)
            {
                Parallel.For(0, N, i => { c[i] = a[i] + b[i]; });
            }
    
            static void Main(string[] args)
            {
                int count = 1024*1024;
    
                IntResidentArray a = new IntResidentArray(count);
                IntResidentArray b = new IntResidentArray(count);
                IntResidentArray c = new IntResidentArray(count);
    
                for (int k = 0; k < count; ++k)
                {
                    a[k] = k + 1;
                    b[k] = 10 * (k + 1);
                }
    
                Console.Out.WriteLine("c status is {0}", c.Status);
    
                cudaDeviceProp prop;
                cuda.GetDeviceProperties(out prop, 0);
                //if .SetDistrib is not used, the default is .SetDistrib(prop.multiProcessorCount * 16, 128)
                HybRunner runner = HybRunner.Cuda();
    
                // create a wrapper object to call GPU methods instead of C#
                dynamic wrapped = runner.Wrap(new Program());
    
                for (int k = 0; k < 10; ++k)
                {
                    wrapped.Run(count, a, b, c);
                }
    
                Console.Out.WriteLine("c status is {0}", c.Status);
    
                Console.Out.WriteLine("C = {0} , {1} , {2} , ...", c[0], c[1], c[2]);
    
                Console.Out.WriteLine("DONE");
            }
        }
    }
