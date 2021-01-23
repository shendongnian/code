    // Replace c:\temp\temp.txt with you original file.
    // Replace c:\temp\temp2.txt with your temporary new file.
    using (var r = new StreamReader(@"c:\temp\temp.txt"))
    {
        using (var w = new StreamWriter(@"c:\temp\temp2.txt"))
        {
            string line;
            var counter = new Dictionary<string, int>();
            // write header first, no changes necessary
            if ((line = r.ReadLine()) != null)
            {
                w.WriteLine(line);
            }
            while ((line = r.ReadLine()) != null)
            {
                // assuming it is safe to split on a space
                var values = line.Split(' ');
                // if the value hasn't been encountered before, add it
                if (!counter.ContainsKey(values[0]))
                {
                    // start counter at 0
                    counter.Add(values[0], 0);
                }
                // increment the count as we hit each occurrence of the
                // given key
                counter[values[0]] = counter[values[0]] + 1;
                // write out the original line, replacing the key with the
                // format key-#
                w.WriteLine(line.Replace(values[0], 
                                         string.Format("{0}-{1}", 
                                                       values[0], 
                                                       counter[values[0]])));
            }
        }
    }
