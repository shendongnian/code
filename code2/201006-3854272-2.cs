    public sealed class LineCounterPatternConverter : PatternLayoutConverter
    {       
        private static int _counter = 0;
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            var counter = System.Threading.Interlocked.Increment(ref _counter);
            writer.Write(counter.ToString());
        }
    }
