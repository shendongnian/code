    static void Main(string[] args)
    {
      var engine = new FileHelperAsyncEngine<Agents>();
      var outEngine = new FileHelperAsyncEngine<Agents>();
      using (engine.BeginReadFile(@"C:\Users\me\Documents\Agents.csv"))
      using (outEngine.BeginWriteFile(@"C:\Users\me\Documents\Output.csv"))
      {
        int pId = 100;
        // The engine is IEnumerable
        foreach (var record in engine)
        {
            record.PersonID = pId.ToString();
            pId++;
            outEngine.WriteNext(record);
          }
      }
    }
