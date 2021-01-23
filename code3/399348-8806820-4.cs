    public class InputFile
    {
        private readonly string _path;
        public InputFile(string path)
        {
            _path = path;
        }
        public IEnumerable<InputLine> GetLines()
        {
            return
                from line in File.ReadAllLines(_path)
                let parts = line.Split(',')
                select new InputLine { Id = parts[0], Value = parts[1] };
        }
    }
    public class OutputFile
    {
        private readonly string _path;
        public OutputFile(string path)
        {
            _path = path;
        }
        public void WriteLines(IEnumerable<OutputLine> lines)
        {
            File.WriteAllLines(_path, lines.Select(line => String.Join(",", line.Id, line.Value1, line.Value2)));
        }
    }
