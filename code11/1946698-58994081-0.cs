    private int[] delayParametersIndexSetup = new int[] { 1, 0, 0, 1, 1, 0, 0, 1 };
    private (int delayWheel, int delayDiag) delayParameters = (1, 500);
    
    public void Go()
    {
        foreach (var index in delayParametersIndexSetup)
        {
            ITuple value = this.delayParameters.ToTuple();
            var v = value[index];
            Console.WriteLine(v);
        }
    }
