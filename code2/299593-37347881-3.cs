    [TestFixture]
    public class Test
    {
        // short input
        //private const string input = "123 123 \t 1adc \n 222";
        //private const string expected = "1231231adc222";
    
        // long input
        private const string input = "123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222";
        private const string expected = "1231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc222";
        
        private const int iterations = 1000000;
    
        [Test]
        public void RemoveStringReader()
        {
            string s = null;
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                s = RemoveWhitespace.RemoveStringReader(input);
            }
    
            stopwatch.Stop();
            Console.WriteLine("String reader: " + stopwatch.ElapsedMilliseconds + "ms");
            Assert.AreEqual(expected, s);
        }
    
        [Test]
        public void RemoveLinqNativeCharIsWhitespace()
        {
            string s = null;
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                s = RemoveWhitespace.RemoveLinqNativeCharIsWhitespace(input);
            }
    
            stopwatch.Stop();
            Console.WriteLine("Linq using native char.IsWhitespace: " + stopwatch.ElapsedMilliseconds + "ms");
            Assert.AreEqual(expected, s);
        }
    
        [Test]
        public void RemoveLinq()
        {
            string s = null;
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                s = RemoveWhitespace.RemoveLinq(input);
            }
    
            stopwatch.Stop();
            Console.WriteLine("Linq: " + stopwatch.ElapsedMilliseconds + "ms");
            Assert.AreEqual(expected, s);
        }
    
        [Test]
        public void RemoveRegex()
        {
            string s = null;
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                s = RemoveWhitespace.RemoveRegex(input);
            }
    
            stopwatch.Stop();
            Console.WriteLine("Regex: " + stopwatch.ElapsedMilliseconds + "ms");
    
            Assert.AreEqual(expected, s);
        }
    
        [Test]
        public void RemoveRegexCompiled()
        {
            string s = null;
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                s = RemoveWhitespace.RemoveRegexCompiled(input);
            }
    
            stopwatch.Stop();
            Console.WriteLine("RegexCompiled: " + stopwatch.ElapsedMilliseconds + "ms");
    
            Assert.AreEqual(expected, s);
        }
    
        [Test]
        public void RemoveForLoop()
        {
            string s = null;
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                s = RemoveWhitespace.RemoveForLoop(input);
            }
    
            stopwatch.Stop();
            Console.WriteLine("ForLoop: " + stopwatch.ElapsedMilliseconds + "ms");
    
            Assert.AreEqual(expected, s);
        }
    }
