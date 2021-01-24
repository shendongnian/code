    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    
    namespace ArrayWrapper
    {
        class ArrayPerformanceTest
        {
            int xSize = 2;
            int ySize = 3;
            int zSize = 4;
            int count = 100000000;
            int delay = 500;
    
            static void Main(string[] args)
            {
                new ArrayPerformanceTest().Run();
            }
    
            private void Run()
            {
    
                var d3Array = CreateD3Array();
                var wrapped = GetD1Adapter(d3Array);
                var jagged = GetJaggedArray(d3Array);
    
                Thread.Sleep(delay);
                TestD3Array(d3Array);
                Thread.Sleep(delay);
                TestWrappedArray(wrapped);
                Thread.Sleep(delay);
                TestJaggeddArray(jagged);
                Thread.Sleep(delay);
            }
    
            private int[,,] CreateD3Array()
            {
                var rectangular = new int[xSize, ySize, zSize];
    
                int i = 7;
                for (var x = 0; x < xSize; x++)
                    for (var y = 0; y < ySize; y++)
                        for (var z = 0; z < zSize; z++)
                            rectangular[x, y, z] = ++i;
    
                return rectangular;
            }
    
            private int[] GetD1Adapter(int[,,] d3Array)
            {
                return d3Array.Cast<int>().ToArray();
            }
    
            private int[][][] GetJaggedArray(int[,,] d3Array)
            {
                var xSize = d3Array.GetUpperBound(0) + 1;
                var ySize = d3Array.GetUpperBound(1) + 1;
                var zSize = d3Array.GetUpperBound(2) + 1;
    
                var jagged = new int[xSize].Select(j => new int[ySize].Select(k => new int[zSize].ToArray()).ToArray()).ToArray();
    
                for (var x = 0; x < xSize; x++)
                    for (var y = 0; y < ySize; y++)
                        for (var z = 0; z < zSize; z++)
                            jagged[x][y][z] = d3Array[x, y, z];
    
                return jagged;
            }
    
            private void TestD3Array(int[,,] d3Array)
            {
                int i;
                var sw = new Stopwatch();
                sw.Start();
                for (var c = 0; c < count; c++)
                    for (var x = 0; x < xSize; x++)
                        for (var y = 0; y < ySize; y++)
                            for (var z = 0; z < zSize; z++)
                                i = d3Array[x, y, z];
                sw.Stop();
                Console.WriteLine($"{nameof(d3Array),7} {sw.ElapsedTicks,10}");
            }
    
            private void TestWrappedArray(int[] wrapped)
            {
                int i;
                var sw = new Stopwatch();
                sw.Start();
                for (var c = 0; c < count; c++)
                    for (var x = 0; x < xSize; x++)
                        for (var y = 0; y < ySize; y++)
                            for (var z = 0; z < zSize; z++)
                                i = wrapped[x * ySize * zSize + y * zSize + z];
                sw.Stop();
                Console.WriteLine($"{nameof(wrapped),7} {sw.ElapsedTicks,10}");
            }
    
            private void TestJaggeddArray(int[][][] jagged)
            {
                int i;
                var sw = new Stopwatch();
                sw.Start();
                for (var c = 0; c < count; c++)
                    for (var x = 0; x < xSize; x++)
                        for (var y = 0; y < ySize; y++)
                            for (var z = 0; z < zSize; z++)
                                i = jagged[x][y][z];
                sw.Stop();
                Console.WriteLine($"{nameof(jagged),7} {sw.ElapsedTicks,10}");
            }
        }
    }
