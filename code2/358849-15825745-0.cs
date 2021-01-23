    public class TeeTextWriter : TextWriter
    {
        readonly TextWriter[] _redirectTo;
        public override Encoding Encoding { get { return Encoding.UTF8; } }
        public TeeTextWriter(params TextWriter[] redirectTo)
        {
            _redirectTo = redirectTo ?? new TextWriter[0];
        }
        public override void Write(char value)
        {
            foreach (var textWriter in _redirectTo)
            {
                textWriter.Write(value);
            }
        }
    }
