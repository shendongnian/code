    public void SerializeState(string filename, ProgramState ps)
    {
     Stream s = File.Open(filename, FileMode.Create);
     BinaryFormatter bFormatter = new BinaryFormatter();
     bFormatter.AssemblyFormat =
        System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
     bFormatter.Serialize(s, ps);
     s.Close();
    }
