    static class ReadLinesHelper
    {
        public static IEnumerator<string>[] ToAllReadLinesOrNothing(this IEnumerable<string> files)
        {
            var exceptions = new List<Exception>();
            var enumerators = files
                .Select(f =>
                {
                    try
                    {
                        return File.ReadLines(f).GetEnumerator();
                    }
                    catch (Exception e)
                    {
                        exceptions.Add(e);
                        return null;
                    }
                })
                .Where(f => f != null)
                .ToArray();
            if (exceptions.Count == 0)
                return enumerators;
            foreach (var i in enumerators)
            {
                try
                {
                    i.Dispose();
                }
                catch (Exception e)
                {
                    exceptions.Add(e);
                }
            }
            throw new AggregateException(exceptions);
        }
    }
