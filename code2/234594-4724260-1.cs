    public interface IA
        {
            int doA(int i);
        }
        public class B
        {
            private IA callee;
            public B(IA callee)
            {
                this.callee = callee;
            }
            public int doB(int i)
            {
                Console.WriteLine("B called with " + i);
                var res = callee.doA(i);
                Console.WriteLine("Delegate returned " + res);
                return res;
            }
        }
        [Test]
        public void TEST()
        {
            var mock = new Mock<IA>();
            mock.Setup(a => a.doA(It.IsInRange(-5, 100, Range.Exclusive))).Returns((int i) => i * i);
            var b = new B(mock.Object);
            for (int i = 0; i < 10; i++)
            {
                b.doB(i);
            }
            mock.Verify(a => a.doA(It.IsInRange(0, 4, Range.Inclusive)), Times.Exactly(5));
            mock.Verify(a => a.doA(It.IsInRange(5, 9, Range.Inclusive)), Times.Exactly(5));
            mock.Verify(a => a.doA(It.Is<int>(i => i < 0)), Times.Never());
            mock.Verify(a => a.doA(It.Is<int>(i => i > 9)), Times.Never());
            mock.Verify(a => a.doA(It.IsInRange(3, 7, Range.Inclusive)), Times.Exactly(5));
            // line below will fail
            // mock.Verify(a => a.doA(It.IsInRange(3, 7, Range.Inclusive)), Times.Exactly(7));
        }
