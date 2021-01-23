    using System;
    using System.Collections.Generic;
    public class FloydWarshallPathFinder {
        private int N;
        private int[,] D;
        private int[,] R;
        public FloydWarshallPathFinder(int NumberOfVertices, int[,] EdgesLengths) {
            N = NumberOfVertices;
            D = EdgesLengths;
            R = null;
        }
        public int[,] FindAllPaths() {
            R = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int t = 0; t < N; t++)
                {
                    R[i, t] = t;
                }
            }
            for (int k = 0; k < N; k++)
            {
                for (int v = 0; v < N; v++)
                {
                    for (int u = 0; u < N; u++)
                    {
                        if (D[u, k] + D[k, v] < D[u, v])
                        {
                            D[u, v] = D[u, k] + D[k, v];
                            R[u, v] = R[u, k];
                        }
                    }
                }
            }
            return R;
        }
        public List<Int32> FindShortestPath(int start, int end) {
            if (R == null) {
                FindAllPaths();
            }
            List<Int32> Path = new List<Int32>();
            while (start != end)
            {
                Path.Add(start);
                start = R[start, end];
            }
            Path.Add(end);
            return Path;
        }
    }
    public class MainClass
    {
        public static void Main()
        {
            int N = 4;
            int[,] D = new int[N, N];
            for (int i = 0; i < N; i++) {
                for (int t = 0; t < N; t++) {
                    if (i == t) {
                        D[i, t] = 0;
                    } else {
                        D[i, t] = 9999;
                    }
                }
            }
            D[0, 2] = 1;
            D[1, 0] = 7;
            D[1, 2] = 6;
            D[2, 3] = 5;
            D[3, 1] = 2;
            FloydWarshallPathFinder pathFinder = new FloydWarshallPathFinder(N, D);
            int start = 0;
            int end = 1;
            Console.WriteLine("Path: {0}", String.Join(" -> ", pathFinder.FindShortestPath(start, end).ToArray()));
        }
    }
