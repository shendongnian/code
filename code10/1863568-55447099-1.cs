    public struct DataPoint
    {
        // The fields below default to 0 which are interpreted as hadn't been
        // set yet. If the value is negative then it represents an error,
        // and if the value is positive it is set.
        public float Position;
        public float Voltage;
        public const string Error = "!FF10";
        // Check the both fields are non-zero (have been set).
        public bool IsOK => Position!=0 && Voltage!=0;
        
        public override string ToString()
        {
            // Convert the two fields into a comma separated string line
            var pos_str = Position>0 ? Position.ToString() :
                Position==0 ? string.Empty : DataPoint.Error;
            var vlt_str = Voltage>0 ? Voltage.ToString() :
                Voltage==0 ? string.Empty : DataPoint.Error;
            return $"{pos_str},{vlt_str}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Process in the data and generate an array of DataPoint
            DataPoint[] input = ProcessFile(File.OpenText("RawData.txt"));
            // Display the items in the array as a table in the console
            int index = 0;
            // Three columns with widths, 5, 12 and 9
            Console.WriteLine($"{"Index",-5} {"Pos",-12} {"Volts",-9}");
            foreach (DataPoint item in input)
            {
                index++;
                // Each DataPoint contains data (floating point numbers),
                // and can be converted into a comma separated string using
                // the .ToString() method.
                var parts = item.ToString().Split(',');
                Console.WriteLine($"{index,-5} {parts[0],-12} {parts[1],-9}");
            }
            
        }
        static DataPoint[] ProcessFile(StreamReader reader)
        {
            var list = new List<DataPoint>();
            // current data to be filled by reader
            DataPoint data = new DataPoint();
            // keep track if the next input is for
            // position or voltage.
            bool expect_position_value = false;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine().Trim();
                // each line is either:
                // * blank
                // * position data, 12 char, numeric
                // * voltage data, 9 char, numeric
                // * error code "!FF10"
                // but random line feeds exist in the file.
                if (string.IsNullOrEmpty(line))
                {
                    // empty line, do nothing
                    continue;
                }
                if (line.StartsWith(">"))
                {
                    // prompt line, do nothing
                    continue;
                }
                // flip the expected value between position & voltage
                expect_position_value=!expect_position_value;
                if (!line.StartsWith(DataPoint.Error) 
                        && line.Length!=9 && line.Length!=12)
                {
                    // Data was split by a line feed. Read
                    // next line and combine together.
                    var next = reader.ReadLine().Trim();
                    Debug.WriteLine(next);
                    line+=next;
                }
                if (line.StartsWith(DataPoint.Error))
                {
                    // Error value
                    if (expect_position_value)
                    {
                        data.Position=-1;
                    }
                    else
                    {
                        data.Voltage=-1;
                    }
                    if (data.IsOK)
                    {
                        list.Add(data);
                        data=new DataPoint();
                        expect_position_value=false;
                    }
                    continue;
                }
                if (line.Length==12)
                {
                    // position value
                    if (float.TryParse(line, out float position))
                    {
                        data.Position=position;
                        expect_position_value=true;
                    }
                    else
                    {
                        // cannot read position, what now?
                    }
                }
                if (line.Length==9)
                {
                    // voltage value
                    if (float.TryParse(line, out float voltage))
                    {
                        data.Voltage=voltage;
                        expect_position_value=false;
                    }
                    else
                    {
                        // cannot read voltage. what now?
                    }
                }
                if (data.IsOK)
                {
                    // data has been filled. Add to list and get
                    // ready for next data point.
                    list.Add(data);
                    data=new DataPoint();
                }
            }
            // Export array of data.
            return list.ToArray();
        }
    }
