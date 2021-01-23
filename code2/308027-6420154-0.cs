        // Write Double
        FileStream FS = new FileStream(@"C:\Test.bin", FileMode.Create);
        BinaryWriter BW = new BinaryWriter(FS);
        double Data = 123.456;
        BW.Write(Data);
        BW.Close();
        // Read Double
        FS = new FileStream(@"C:\Test.bin", FileMode.Open);
        BinaryReader BR = new BinaryReader(FS);
        Data = BR.ReadDouble();
        BR.Close();
