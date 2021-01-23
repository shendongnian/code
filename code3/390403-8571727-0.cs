    // deliberately made hard to optimise without whole program optimisation
    public static int[] data = new int[1000000]; // long[] when testing long
    // I happened to have a winforms app open, feel free to make this a console app..
    private void button1_Click(object sender, EventArgs e)
    {
        long best = long.MaxValue;
        for (int j = 0; j < 1000; j++)
        {
            Stopwatch timer = Stopwatch.StartNew();
            int a1 = ~0, b1 = 0x55555555, c1 = 0x12345678; // varies: see below
            int a2 = ~0, b2 = 0x55555555, c2 = 0x12345678;
            int[] d = data; // long[] when testing long
            for (int i = 0; i < d.Length; i++)
            {
                int v = d[i]; // long when testing long, see below
                a1 &= v; a2 &= v;
                b1 &= v; b2 &= v;
                c1 &= v; c2 &= v;
            }
            // don't average times: we want the result with minimal context switching
            best = Math.Min(best, timer.ElapsedTicks); 
            button1.Text = best.ToString() + ":" + (a1 + a2 + b1 + b2 + c1 + c2).ToString("X8");
        }
    }
