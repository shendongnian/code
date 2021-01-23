    [TestFixture]
    public class Test
    {
        // Short input
        //private const string input = "123 123 \t 1adc \n 222";
        //private const string expected = "1231231adc222";
        // Long input
        private const string input = "123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222123 123 \t 1adc \n 222";
        private const string expected = "1231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc2221231231adc222";
        private const int iterations = 1000000;
        [Test]
        public void RemoveInPlaceCharArray()
        {
            string s = null;
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                s = RemoveWhitespace.RemoveInPlaceCharArray(input);
            }
            stopwatch.Stop();
            Console.WriteLine("InPlaceCharArray: " + stopwatch.ElapsedMilliseconds + " ms");
            Assert.AreEqual(expected, s);
        }
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
            Console.WriteLine("String reader: " + stopwatch.ElapsedMilliseconds + " ms");
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
            Console.WriteLine("LINQ using native char.IsWhitespace: " + stopwatch.ElapsedMilliseconds + " ms");
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
            Console.WriteLine("LINQ: " + stopwatch.ElapsedMilliseconds + " ms");
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
            Console.WriteLine("Regex: " + stopwatch.ElapsedMilliseconds + " ms");
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
            Console.WriteLine("RegexCompiled: " + stopwatch.ElapsedMilliseconds + " ms");
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
            Console.WriteLine("ForLoop: " + stopwatch.ElapsedMilliseconds + " ms");
            Assert.AreEqual(expected, s);
        }
        [TestMethod]
        public void StringSplitThenJoin()
        {
            string s = null;
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                s = RemoveWhitespace.StringSplitThenJoin(input);
            }
            stopwatch.Stop();
            Console.WriteLine("StringSplitThenJoin: " + stopwatch.ElapsedMilliseconds + " ms");
            Assert.AreEqual(expected, s);
        }
    }
