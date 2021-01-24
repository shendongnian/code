    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    class LineReader : IDisposable
    {
        private StreamReader reader = null;
        private Dictionary<long, long> positions;
        private string m_filePath = string.Empty;
        private Encoding m_encoding = null;
        private IEnumerable<Control> m_controls = null;
        private string m_separator = string.Empty;
        private bool m_associate = false;
        private long m_currentPosition = 0;
        private bool m_hasHeader = false;
        public LineReader(string filePath) : this(filePath, false) { }
        public LineReader(string filePath, bool hasHeader) : this(filePath, hasHeader, Encoding.ASCII) { }
        public LineReader(string filePath, bool hasHeader, Encoding encoding)
        {
            if (!File.Exists(filePath)) {
                throw new FileNotFoundException($"The file specified: {filePath} was not found");
            }
            this.m_filePath = filePath;
            m_hasHeader = hasHeader;
            CurrentLineNumber = 0;
            reader = new StreamReader(this.m_filePath, encoding, true);
            CurrentLine = reader.ReadLine();
            m_encoding = reader.CurrentEncoding;
            m_currentPosition = m_encoding.GetPreamble().Length;
            positions = new Dictionary<long, long>() { [0]= m_currentPosition };
            if (hasHeader) { this.HeaderLine = CurrentLine = this.MoveNext(); }
        }
        public string HeaderLine { get; private set; }
        public string CurrentLine { get; private set; }
        public long CurrentLineNumber { get; private set; }
        public string MoveNext()
        {
            string read = reader.ReadLine();
            if (string.IsNullOrEmpty(read)) return this.CurrentLine;
            CurrentLineNumber += 1;
            if ((positions.Count - 1) < CurrentLineNumber) {
                AdjustPositionToLineFeed();
                positions.Add(CurrentLineNumber, m_currentPosition);
            }
            else {
                m_currentPosition = positions[CurrentLineNumber];
            }
            this.CurrentLine = read;
            if (m_associate) this.Associate();
            return read;
        }
        public string MovePrevious()
        {
            if (CurrentLineNumber == 0 || (CurrentLineNumber == 1 && m_hasHeader)) return this.CurrentLine;
            CurrentLineNumber -= 1;
            m_currentPosition = positions[CurrentLineNumber];
            reader.BaseStream.Position = m_currentPosition;
            reader.DiscardBufferedData();
            this.CurrentLine = reader.ReadLine();
            if (m_associate) this.Associate();
            return this.CurrentLine;
        }
        private void AdjustPositionToLineFeed()
        {
            long linePos = m_currentPosition + m_encoding.GetByteCount(this.CurrentLine);
            long prevPos = reader.BaseStream.Position;
            reader.BaseStream.Position = linePos;
            byte[] buffer = new byte[4];
            reader.BaseStream.Read(buffer, 0, buffer.Length);
            char[] chars = m_encoding.GetChars(buffer).Where(c => c.Equals((char)10) || c.Equals((char)13)).ToArray();
            m_currentPosition = linePos + m_encoding.GetByteCount(chars);
            reader.BaseStream.Position = prevPos;
        }
        public void AssociateControls(IEnumerable<Control> controls, string separator)
        {
            m_controls = controls;
            m_separator = separator;
            m_associate = true;
            if (!string.IsNullOrEmpty(this.CurrentLine)) Associate();
        }
        private void Associate()
        {
            string[] values = this.CurrentLine.Split(new[] { m_separator }, StringSplitOptions.None);
            int associate = 0;
            m_controls.ToList().ForEach(c => {
                if (c != null) c.Text = values[associate];
                associate += 1;
            });
        }
        public override string ToString() =>
            $"File Path: {m_filePath} Encoding: {m_encoding.BodyName} CodePage: {m_encoding.CodePage}";
       ~LineReader() { Dispose(false); }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) { reader?.Dispose(); }
        }
    }
