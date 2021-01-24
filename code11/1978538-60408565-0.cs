    {
      ...
      // bw will be closed on leaving its scope  
      using BinaryWriter bw = new BinaryWriter(File.OpenWrite("asdf"));
      bw.Write(dFoo);
      bw.Write(BitConverter.GetBytes(dFoo));
      ...
    } // bw will be closed here (with all data cached being written)
