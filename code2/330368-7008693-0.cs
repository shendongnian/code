            using (var stream = File.OpenRead("C:\\yourfile"))
            {
                var items = new LinkedList<string>();
                using (var reader = new StreamReader(stream))
                {
                    reader.ReadLine(); // skip one line
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        //it's far better to do the actual processing here
                        items.AddLast(line);
                    }
                }
            }
