        static void Main()
        {
            Console.WriteLine(DateTime.Now + " generate some fake data");
            StringBuilder datasb = new StringBuilder(100 * 1024 * 1024);//initialize for 100 megabytes
            var para = new List<Guid>();
            for (int i = 0; i < 500000; i++) {
                var g = Guid.NewGuid();
                datasb.AppendFormat(">{0} datapointname{1}\r\nInformation; generated at {2}\r\n", g, i, DateTime.Now);
                if (i % 20000 == 0) //25 items in 500,000
                    para.Add(g);
                if (i % 40000 == 0) //~12 items not findable in 500,000
                    para.Add(Guid.NewGuid());
            }
            var pfile = string.Join("\r\n", para.OrderBy(g => g.ToString()));
            string datafile = @"C:\temp\text.txt";
            string inputfile = @"C:\temp\input.txt";
            string outputfile = @"C:\temp\output.txt";
            //write fake files
            File.WriteAllText(datafile, datasb.ToString());
            File.WriteAllText(inputfile, pfile);
            var start = DateTime.Now;
            Console.WriteLine(DateTime.Now + " begin loading dictionary");
            //BEGIN USEFUL PART
            string[] parameters = System.IO.File.ReadAllLines(inputfile);
            string[] data = System.IO.File.ReadAllLines(datafile);
            var index = new Dictionary<string, Thing>();
            for (int i = 0; i < data.Length - 1; i += 2)
            {
                string currentline = data[i];
                string[] splitline = currentline.Split(' ');
                Thing t = new Thing()
                {
                    DataPointNumber = splitline[0].Trim('>'),
                    DataPointName = splitline[1],
                    Information = data[i + 1],
                    LineNumber = i
                };
                index[t.DataPointNumber] = t;
            }
            Console.WriteLine(DateTime.Now + " begin searching dictionary");
            int found = 0, notFound = 0;
            foreach (var p in parameters)
            {
                if (index.ContainsKey(p))
                {
                    Console.WriteLine($" Found {p}: {index[p]}"); //ToString will be called
                    found++;
                }
                else
                {
                    Console.WriteLine($" File doesn't contain {p}");
                    notFound++;
                }
            }
            Console.WriteLine($"{DateTime.Now } search complete, searched {index.Count} items looking for {parameters.Length} items, found {found}, didnt find {notFound}, took {(DateTime.Now-start).TotalSeconds} seconds");
        }
