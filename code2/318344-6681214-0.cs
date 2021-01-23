    using (System.IO.StreamReader sr = new System.IO.StreamReader(@"C:\mydata.dat"))
    {
        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\mynewdata.dat"))
        {
            byte[] bytes = new byte[1024];
            int count = 0;
            while((count = sr.BaseStream.Read(bytes, 0, bytes.Length)) > 0){
                sw.BaseStream.Write(bytes, 0, count);
            }
        }
    }
