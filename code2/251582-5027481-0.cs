    using (StreamReader sr = new StreamReader(@"test.txt"))
    {
        using (StreamWriter sw = new StreamWriter(@"modifiedtest.txt"))
        {
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                //do some modifications
                sw.WriteLine(line);
                sw.Flush(); //force line to be written to disk
            }
        }
    }
