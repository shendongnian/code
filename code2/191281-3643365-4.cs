    static void Test2(int[] a)
    {
        int N = a.Length;
        int total = 0;
        Object locker = new object();
        Parallel.For(0, N, i => 
        {
           for (int j = i + 1; j < N; ++j)
                for (int k = j + 1; k < N; ++k)
                    if (a[i] + a[j] + a[k] == 30)
                        lock(locker)
                            total++; 
        });
    }
