    public void InjectMissingData()
    {
        DataLine lastDataLine = null;
        using (var writer = new StreamWriter(File.Create("c:\\temp\\out.txt")))
        {
            using (var reader = new StreamReader("c:\\temp\\in.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var dataLine = DataLine.Parse(reader.ReadLine());
    
                    while (lastDataLine != null && dataLine.Occurence - lastDataLine.Occurence > TimeSpan.FromSeconds(1))
                    {
                        lastDataLine = new DataLine(lastDataLine.Occurence + TimeSpan.FromSeconds(1), lastDataLine.Data);
                        writer.WriteLine(lastDataLine.Line);
                    }
    
                    writer.WriteLine(dataLine.Line);
    
                    lastDataLine = dataLine;
                }
            }
        }
    }
    
    public class DataLine
    {
        public static DataLine Parse(string line)
        {
            var timeString = string.Format("{0}:{1}:{2}", line.Substring(0, 2), line.Substring(2, 2),
                                           line.Substring(4, 2));
    
            return new DataLine(TimeSpan.Parse(timeString), long.Parse(line.Substring(7, line.Length - 7).Trim()));
        } 
    
        public DataLine(TimeSpan occurence, long data)
        {
            Occurence = occurence;
            Data = data;
        }
    
        public TimeSpan Occurence { get; private set; }
        public long Data { get; private set; }
    
        public string Line
        {
            get { return string.Format("{0}{1}{2} {3}", 
                Occurence.Hours.ToString().PadLeft(2, Char.Parse("0")), 
                Occurence.Minutes.ToString().PadLeft(2, Char.Parse("0")), 
                Occurence.Seconds.ToString().PadLeft(2, Char.Parse("0")),
                Data); }
        }
    }
