    using System;
    using System.Net;
    using System.Collections.Generic;
    using System.IO;
    
    using Shared;
    using Shared.IO;
    using Shared.OpenCL;
    
    namespace Testing
    {
        public class ApplicationClass
        {
    		static Random rand = new Random();
    		
    		static Single[] RandomArray(Int32 length)
    		{
    			Single[] result = new Single[length];
    			
    			for (int i = 0; i < result.Length; i++)
    			{
    				result[i] = (Single)rand.NextDouble();
    			}
    			
    			return result;
    		}
    		
            static void Main(string[] args)
            {
    			DeviceGlobalMemory output = new Byte[4096];
    			
                DeviceGlobalMemory indeces = RandomArray(102400);
                DeviceGlobalMemory ops = new Byte[3072];
                DeviceGlobalMemory data = RandomArray(1048576);
    						
                Console.Write("Creating kernel...");
    
    			Kernel kernel = Kernel.Create("Kernel", File.ReadAllText("Test.c"), data, indeces, ops, output);
    
                Console.Write("Executing kernel...");
    
                Event e = kernel.Execute(256, 256);
    			
                kernel.CommandQueue.Finish();
    			
    			Console.WriteLine("done, operation took {0}", Profiler.DurationSeconds(e));
    			
                UnmanagedReader reader = new UnmanagedReader(new DeviceBufferStream(output));
    						
    			for (int i = 0; i < 256; i++)
    			{
    				if (i % 4 == 0) Console.WriteLine();
    				if (i % 16 == 0) Console.WriteLine();
    				
    	            Console.Write("{0}\t", reader.Read<Single>());
    			}
            }
        }
    }
