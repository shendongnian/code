    public ProgramState DeserializeState(string filename)
    {
     if (File.Exists(filename))
     {
      ProgramState res = new ProgramState();
      Stream s = File.Open(filename, FileMode.Open);
      BinaryFormatter bFormatter = new BinaryFormatter();
      bFormatter.AssemblyFormat =
        System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
      bFormatter.Binder = new MyBinder(); // MyBinder class code given below
      try
      {
       res = (ProgramState)bFormatter.Deserialize(s);
      }
      catch (SerializationException se)
      {
       Debug.WriteLine(se.Message);
      }
      s.Close();
      return res;
     }
     else return new ProgramState();
    }
