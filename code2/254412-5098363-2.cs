        public static IEnumerable<T> Trace<T>(this IEnumerable<T> input, 
                                                string format, 
                                                params object[] data) 
        {
            if (input == null)
                throw new ArgumentNullException("input");
            return TraceImpl(input, format, data);
        }
        private static IEnumerable<T> TraceImpl<T>(IEnumerable<T> input, 
                                                    string format, 
                                                    params object[] data) 
        {
            System.Diagnostics.Trace.WriteLine(string.Format(format, data));
            foreach (T element in input)
                yield return element;
        }
