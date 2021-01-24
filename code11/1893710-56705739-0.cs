    using Hybridizer.Runtime.CUDAImports;
    using System;
    using System.Runtime.InteropServices;
    
    namespace SimpleMetadataDecorator
    {
        class Program
        {
            [EntryPoint]
            public static void Total(FloatResidentArray a, int N, float[] total)
            {
                var cache = new SharedMemoryAllocator<float>().allocate(blockDim.x);
    
                int tid = threadIdx.x + blockDim.x * blockIdx.x;
                int cacheIndex = threadIdx.x;
                float sum = 0f;
                while (tid < N)
                {
                    sum = sum + a[tid];
                    tid += blockDim.x * gridDim.x;
                }
                cache[cacheIndex] = sum;
                CUDAIntrinsics.__syncthreads();
                int i = blockDim.x / 2;
                while (i != 0)
                {
                    if (cacheIndex < i)
                    {
                        cache[cacheIndex] = cache[cacheIndex] + cache[cacheIndex + i];
                    }
                    CUDAIntrinsics.__syncthreads();
                    i >>= 1;
                }
    
                if (cacheIndex == 0)
                {
                    AtomicExpr.apply(ref total[0], cache[0], (x, y) => x + y);
                }
            }
            static void Main(string[] args)
            {
    
                const int N = 1024 * 1024 * 32;
                FloatResidentArray arr = new FloatResidentArray(N);
                float[] res = new float[1];
                for (int i = 0; i < N; ++i)
                {
                    arr[i] = 1.0F;
                }
    
                arr.RefreshDevice();
                var runner = HybRunner.Cuda();
                cudaDeviceProp prop;
                cuda.GetDeviceProperties(out prop, 0);
                runner.SetDistrib(16 * prop.multiProcessorCount, 1, 128, 1, 1, 128 * sizeof(float));
                var wrapped = runner.Wrap(new Program());
                runner.saveAssembly();
                cuda.ERROR_CHECK((cudaError_t)(int)wrapped.Total(arr, N, res));
                cuda.ERROR_CHECK(cuda.DeviceSynchronize());
                Console.WriteLine(res[0]);
    
            }
        }
    }
