            public static int ContainsAnyOfAt<T>(this global::System.String source, IEnumerable<T> values)
            {
                if (source == null) throw new ArgumentNullException("source");
                for (int i = 0; i < values.Count(); i++)
                {
                    if (source.Contains(values.ElementAt(i).ToString()))
                    {
                        return i;
                    }
                }
                return -1;
            }
