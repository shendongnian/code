    using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    string[] def_arr = null;
                    var line1 = reader.ReadLine();
                    if (line1.Contains(".engineering " + name + " ") && !reader.EndOfStream)
                    {
                        var nextLine = reader.ReadLine(); // nextLine contains ".default"
                        while (!nextLine.Contains(".default") && !reader.EndOfStream)
                        {
                            nextLine = reader.ReadLine();
                        }
                        def_arr = nextLine.Split(' ');
                        def_val = def_arr[1].Replace("\"", "");
                        port_DefaultValues.Add(name + ", " + def_val);
                    }
                }
            }
