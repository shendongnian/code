    FileStream fs = new FileStream(strFileName, FileMode.OpenOrCreate);
            if (fs.Length > 500000)
            {
                // Set the length t0 250Kb
                Byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
                fs.Close();
                FileStream fs2 = new FileStream(strFileName, FileMode.Create);
                fs2.Write(bytes, (int)bytes.Length - 250000, 250000);
                fs2.Flush();
            } // end if (fs.Length > 500000) 
