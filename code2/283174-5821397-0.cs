    /// <example>
        /// Console.WriteLine(new LinesItem("X", "X"));
        /// </example>
        public class LinesItem
        {
            private readonly string _lineSeparator;
            private readonly object[] _items;
    
            public LinesItem(params object[] items) : this("\r\n", items)
            {
                _items = items;
            }
    
            public LinesItem(string lineSeparator, params object[] items)
            {
                _lineSeparator = lineSeparator;
                _items = items;
            }
    
            public override string ToString()
            {
                return String.Join(_lineSeparator, _items.Select(x => x.ToString()).ToArray());
            }
        }
    
        //OR
    
        /// <summary>
        /// Because System.Console is a static class you cannot use Extension methods which would
        /// have been nice.  Instead you can simply make another static class to do extra things.
        /// </summary>
        /// <example>
        /// ExtendedConsole.WriteLines("X", "X");
        /// </example>
        public static class ExtendedConsole
        {
            public static void WriteLines(params object[] items)
            {
                foreach(var item in items)
                {
                    Console.WriteLine(item);
                }
            }
        }
