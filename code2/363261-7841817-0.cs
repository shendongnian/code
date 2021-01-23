    string path = "e:\\cc.accdb";
    
    if (File.Exists(path))
    {
        File.Delete(path);
    }    
    
    byte[] bb = { 54, 87, 98, 57, 65 };
    BinaryWriter BW = new BinaryWriter(File.Open(path, FileMode.Create));
    BW.Write(bb);
