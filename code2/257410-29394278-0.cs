    private void calculateSimpleMA(decimal[] values, out decimal[] buffer)
    {
        int period = values.Count();     // gets Period (assuming Period=Values-Array-Size)
        buffer = new decimal[period];    // initializes buffer array
        var sma = SMA(period);           // gets SMA function
        for (int i = 0; i < period; i++)
            buffer[i] = sma(values[i]);  // fills buffer with SMA calculation
    }
    
    static Func<decimal, decimal> SMA(int p)
    {
        Queue<decimal> s = new Queue<decimal>(p);
        return (x) =>
        {
            if (s.Count >= p)
            {
                s.Dequeue();
            }
            s.Enqueue(x);
            return s.Average();
        };
    }
