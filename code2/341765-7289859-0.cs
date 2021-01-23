    string[] ss = File.ReadAllLines(@"path to the file");
    int cycle = 1;
    int chunksize = 300;
    var chunk = ss.Take(chunksize);
    var rem = ss.Skip(chunksize);
    while (chunk.Take(1).Count() > 0)
    {
        string filename = "file" + cycle.ToString() + ".txt";
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach(string line in chunk)
            {
                sw.WriteLine(line);
            }
        }
        chunk = rem.Take(chunksize);
        rem = rem.Skip(chunksize);
        cycle++;
    }
