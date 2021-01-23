    static int GetLength(double d)
    {
        d = Math.Abs(d);
        if (d < 1.0) return 0;
        if (double.IsInfinity(d)) return int.MaxValue;
        if (double.IsNaN(d)) return 0;
        return (int)Math.Floor(Math.Log10(d)) + 1;
    }
    static int GetLength2(double d)
    {
        d = Math.Abs(d);
        if (d < 1.0) return 0;
        if (double.IsInfinity(d)) return int.MaxValue;
        if (double.IsNaN(d)) return 0;
        string s = d.ToString("E"); // returns a string in the format "1.012435E+001"
        return int.Parse(s.Substring(s.Length - 3)) + 1;
    }
    static void Test(double d) { Debug.WriteLine(d + " -> " + GetLength(d) + ", " + GetLength2(d)); }
    static void Main(string[] args)
    {
        Test(0);
        Test(0.125);
        Test(0.25);
        Test(0.5);
        Test(1);
        Test(2);
        Test(10);
        Test(10.5);
        Test(10.25);
        Test(10.1243542354235623542345234523452354);
        Test(999999);
        Test(1000000);
        Test(1000001);
        Test(999999.111);
        Test(1000000.111);
        Test(1000001.111);
        Test(double.MaxValue);
        Test(double.MinValue);
        Test(double.PositiveInfinity);
        Test(double.NegativeInfinity);
        Test(double.NaN);
        Test(double.Epsilon);
    }
