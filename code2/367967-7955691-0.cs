    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    namespace csharp
    {
        public class SomeDTO { }
        public class SomeRepository { public virtual void Write(List<SomeDTO> list) { } }
        public class MainClass
        {
            private SomeRepository someRepository;
            public MainClass(SomeRepository someRepository) { this.someRepository = someRepository; }
            public void DoRepositoryWrite(List<SomeDTO> list) { this.someRepository.Write(list); }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var mockSomeRepository = new Mock<SomeRepository>();
                var mainClass = new MainClass(mockSomeRepository.Object);
                var someList = Enumerable.Repeat(new SomeDTO(), 25).ToList();
                mainClass.DoRepositoryWrite(someList);
                mockSomeRepository.Verify(m => m.Write(It.IsAny<List<SomeDTO>>()), Times.Once(), "Write was not called");
                mockSomeRepository.Verify(m => m.Write(It.Is<List<SomeDTO>>(l => l.Count == 25)), Times.Once(), "Write was not called with a 25-element-list");
            }
        }
    }
