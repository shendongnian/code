    public class SomeDTO { }
    public class SomeRepository
    {
        public virtual void Write(IEnumerable<SomeDTO> list) { }
    }
    public class MainClass
    {
        private readonly SomeRepository _someRepository;
        private readonly List<SomeDTO> _testList = new List<SomeDTO>(); 
        public MainClass(SomeRepository someRepository)
        {
            _someRepository = someRepository;
        }
        public void DoRepositoryWrite()
        {
            _testList.AddRange(Enumerable.Repeat(new SomeDTO(), 25));
            _someRepository.Write(_testList);
            _testList.Clear();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var mockSomeRepository = new Mock<SomeRepository>();
            var mainClass = new MainClass(mockSomeRepository.Object);
            mainClass.DoRepositoryWrite();
            mockSomeRepository.Verify(m => m.Write(It.IsAny<IEnumerable<SomeDTO>>()), Times.Once(), "Write was not called");
            mockSomeRepository.Verify(m => m.Write(It.Is<IEnumerable<SomeDTO>>(l => l.Count() == 25)), Times.Once(), "Write was not called with a 25-element-list");
        }
    }
