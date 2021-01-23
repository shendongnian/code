    private void m_btnTest_Click(object sender, EventArgs e) {
        Stopwatch sw = new Stopwatch();
            
        string s = "";
        string value = new string ('x', 100000);    // 100k string
        int iterations = 10000000;
        //-----------------------------------------------------
        // Update by ref
        //-----------------------------------------------------
        sw.Start();
        for (var n = 0; n < iterations; n++) {
            SetStringValue(ref s, ref value);
        }
        sw.Stop();
        long proc1 = sw.ElapsedMilliseconds;
        sw.Reset();
        //-----------------------------------------------------
        // Update by value
        //-----------------------------------------------------
        sw.Start();
        for (var n = 0; n < iterations; n++) {
            s = SetStringValue(s, value);
        }
        sw.Stop();
        long proc2 = sw.ElapsedMilliseconds;
        //-----------------------------------------------------
        Console.WriteLine("iterations: {0} \nbyref: {1}ms \nbyval: {2}ms", iterations, proc1, proc2);
    }
    public string SetStringValue(string input, string value) {
        input = value;
        return input;
    }
    public void SetStringValue(ref string input, ref string value) {
        input = value;
    }
