    [TestFixture]
    public sealed class TestIterativeRhinoReturn
    {
        private int _count;
        private int _countOfLines; 
        private IList<string> _lines;
        private string _currentLine; 
        [SetUp]
        public void SetUp()
        {
            _count = -1;
            _lines= new List<string>()
                                                {
                                                    "A",
                                                    "B",
                                                    "C",
                                                    null
                                                };
            _countOfLines = _lines.Count;
            _currentLine = null; 
        }
        [Test]
        public void Test()
        {
            MockRepository mockRepository = new MockRepository();
            ILineReader lineReader = mockRepository.DynamicMock<ILineReader>();
            lineReader.Stub(r => r.ReadLine()).Callback(new ReadLineDelegate(ReadRecord)).Return(_count < _countOfLines);
            lineReader.Stub(r => r.CurrentLine()).Do(new CurrentStringDelegate(ReturnString)).Return(_currentLine);
            mockRepository.ReplayAll();
            bool read1 = lineReader.ReadLine();
            Assert.That(read1, Is.True);
            Assert.That(lineReader.CurrentLine(), Is.EqualTo("A"));
            bool read2 = lineReader.ReadLine();
            Assert.That(read2, Is.True);
            Assert.That(lineReader.CurrentLine(), Is.EqualTo("B"));
            bool read3 = lineReader.ReadLine();
            Assert.That(read3, Is.True);
            Assert.That(lineReader.CurrentLine(), Is.EqualTo("C"));
            bool read4 = lineReader.ReadLine();
            Assert.That(read4, Is.False);
            Assert.That(lineReader.CurrentLine(), Is.Null);
        }
        public delegate bool ReadLineDelegate();
        private bool ReadRecord()
        {
            _count++;
            return (_lines[_count]!=null);
        }
        public delegate string CurrentStringDelegate(); 
        
        private string ReturnString()
        {
            return _lines[_count]; 
        }
