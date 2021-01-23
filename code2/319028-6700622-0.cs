    public static void Serialize(Object inst, string filename)
    {
        Type t = inst.GetType();
        DataContractSerializer dcs = new DataContractSerializer(t);
        using (FileStream stream = File.OpenWrite(filename)) {
            dcs.WriteObject(ms, inst);
        }
    }
