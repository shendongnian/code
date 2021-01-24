    using System;
    using Moq;
    namespace Demo
    {
        public interface IConsole
        {
            void WriteLine(string text);
        }
        // Not used but included as an example implementation.
        public sealed class MyConsole : IConsole
        {
            public void WriteLine(string text)
            {
                Console.WriteLine(text);
            }
        }
        public class UnderTest
        {
            public UnderTest(IConsole console)
            {
                _console = console;
            }
            public void WriteLine()
            {
                _console.WriteLine("It works!");
            }
            readonly IConsole _console;
        }
        public class Program
        {
            public static void Main()
            {
                var mock = new Mock<IConsole>();
                var underTest = new UnderTest(mock.Object);
                underTest.WriteLine();
                mock.Verify(x => x.WriteLine("It works!"));
            }
        }
    }
