    static void Main(string[] args)
    {
        List<IWriteStrategy> writeStrategies = new List<IWriteStrategy>()
        {
            new WriterA(),
            new WriterB()
        };
        List<IMaster> executes = new List<IMaster>()
        {
             new MasterOne(),
             new MasterTwo()
        };
        for (int i = 0; i < writeStrategies.Count(); i++)
        {
             writeStrategies[i].Write(executes[i]);
        }
    }
