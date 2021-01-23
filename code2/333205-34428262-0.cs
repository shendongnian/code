    if (!File.Exists(Properties.Resources.DllName))
    {
        var outStream = new StreamWriter(Properties.Resources.DllName, false);
        var binStream = new BinaryWriter(outStream.BaseStream);
        binStream.Write(Properties.Resources.DllFile);
        binStream.Close();
    }
