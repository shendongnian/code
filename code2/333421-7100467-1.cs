    var testAmount = 100;
    int[] a1 = new int[10000000];
    int[] a2 = new int[10000000];
    
    Performance.Test
    (
        "Direct", testAmount, true,
        () =>
        {
            for (int i = 0; i < a1.Length; ++i)
            {
                a1[i] = i;
            }
        }
    );
    
    Performance.Test
    (
        "Cache", testAmount, true,
        () =>
        {
            var l = a2.Length;
            for (int i = 0; i < l; ++i)
            {
                a2[i] = i;
            }
        }
    );
