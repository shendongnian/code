            public static int ContainsAnyOfAt<T>(this global::System.String source, IEnumerable<T> values, int startIndex = 0)
            {
                if (source == null) throw new ArgumentNullException("source");
                for (int i = startIndex ; i < values.Count(); i++)
                {
                    if (source.Contains(values.ElementAt(i).ToString()))
                    {
                        return i;
                    }
                }
                return -1;
            }
