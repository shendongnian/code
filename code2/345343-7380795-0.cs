    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    class Program
    {
        static void AverageOfZ (
            double[] input, 
            double[] result,
            int x, 
            int y, 
            int z
            )
        {
            Debug.Assert(input.Length == x*y*z);
            Debug.Assert(result.Length == x*y);
            //Replace Parallel with Sequential to compare with non-parallel loop
            //Sequential.For(
            Parallel.For(
                0,
                x*y,
                i =>
                    {
                        var begin = i*z;
                        var end = begin + z;
                        var sum = 0.0;
                        for (var iter = begin; iter < end; ++iter)
                        {
                            sum += input[iter];
                        }
                        result[i] = sum/z;
                    });
        }
        static void Main(string[] args)
        {
            const int X = 64;
            const int Y = 64;
            const int Z = 64;
            const int Repetitions = 40000;
            var random = new Random(19740531);
            var samples = Enumerable.Range(0, X*Y*Z).Select(x => random.NextDouble()).ToArray();
            var result = new double[X*Y];
            var then = DateTime.Now;
            for (var iter = 0; iter < Repetitions; ++iter)
            {
                AverageOfZ(samples, result, X, Y, Z);
            }
            var diff = DateTime.Now - then;
            Console.WriteLine(
                "{0} samples processed {1} times in {2} seconds", 
                samples.Length,
                Repetitions,
                diff.TotalSeconds
                );
        }
    }
    static class Sequential
    {
        public static void For(int from, int to, Action<int> action)
        {
            for (var iter = from; iter < to; ++iter)
            {
                action(iter);
            }
        }
    }
