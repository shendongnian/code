            class YourType
            {
                public String Source { get; private set; }
                public String Destination { get; private set; }
                public String Resoult { get; private set; }
                public String Time { get; private set; }
    
                //or func returning bool and remove exception
                public YourType(String line)
                {
                    var split = line.Split(' ');
    
                    if (split.Length != 4)
                        throw new ArgumentException();
    
                    Source = split[0];
                    Destination = split[1];
                    Resoult = split[2];
                    Time = split[3];
                }
    
            }
            
            public Main()
            {
                String values =
     @"source1 destination1 result time
    source2 destination1 result time
    sources3 destination2 result time";
    
    
    
                var v = from line in values.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        select new YourType(line);
    
                foreach (var it in v)
                {
                    Console.WriteLine(it.Source);
                }
    
            }
