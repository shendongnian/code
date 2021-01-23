    /// <summary>
    /// Binary seek for the value where f() becomes false.
    /// </summary>
    void Seek(ref int a, ref int b, int aadd, int badd, Func<int, int, bool> f)
    {
        int weight = 1;
        a += aadd;
        b += badd;
        if (f(a, b))
        {
            do
            {
                weight *= 2;
                a += aadd * weight;
                b += badd * weight;
            }
            while (f(a, b));
        }
        else
        {
            return;
        }
        do
        {
            weight /= 2;
            int asub = aadd * weight;
            int bsub = badd * weight;
            if (!f(a - asub, b - bsub))
            {
                a -= asub;
                b -= bsub;
            }
        }
        while (weight > 1);
    }
