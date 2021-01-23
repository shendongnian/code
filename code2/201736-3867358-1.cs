    TwoFloats[] a = new TwoFloats[10000];
    float[] b = new float[20000];
    void test1()
    {
        int count = 0;
        for (int i = 0; i < 10000; i += 1)
        {
            if (a[i].x < 10) count++;
        }
    }
    void test2()
    {
        int count = 0;
        for (int i = 0; i < 20000; i += 2)
        {
            if (b[i] < 10) count++;
        }
    }
