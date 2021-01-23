    public sealed class LineCounterPatternConverter : PatternLayoutConverter
    {       
        private static int counter = 0;
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            LineCounterPatternConverter.counter++;
            writer.Write(LineCounterPatternConverter.counter.ToString());
        }
    }
