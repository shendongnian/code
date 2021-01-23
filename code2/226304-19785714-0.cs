    [DebuggerStepThrough]
    private A GetA(string b)
    {
        var helper = new Helper { B = b };
        return this.aCollection.FirstOrDefault(helper.AreBsEqual);
    }
    private class Helper
    {
        public string B;
        [DebuggerStepThrough]
        public bool AreBsEqual(A a) { return a.b == this.B; }
    }
