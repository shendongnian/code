    byte[] bytes = null;
    using (System.IO.StreamReader sr = new System.IO.StreamReader(@"C:\mydata.dat"))
    {
        bytes = new byte[sr.BaseStream.Length];
        int index = 0;
        int count = 0;
        while((count = sr.BaseStream.Read(bytes, index, 1024)) > 0){
            index += count;
        }
    }
