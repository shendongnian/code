    public static IEnumerable<string> GetFiles(string root, string spec)
    {
        var pending = new Stack<string>(new []{root});
        while (pending.Count > 0)
        {
            var path = pending.Pop();
            IEnumerator<string> fileIterator = null;
            try
            {
                fileIterator = Directory.EnumerateFiles(path, spec).GetEnumerator();
            }
            catch {}
            if (fileIterator != null)
            {
                using (fileIterator)
                {
                    while (true)
                    {
                        try
                        {
                            if (!fileIterator.MoveNext()) // Throws if file is not accessible.
                                break;
                        }
                        catch { break; }
                        yield return fileIterator.Current;
                    }
                }
            }
            IEnumerator<string> dirIterator = null;
            try
            {
                dirIterator = Directory.EnumerateDirectories(path).GetEnumerator();
            }
            catch {}
            if (dirIterator != null)
            {
                using (dirIterator)
                {
                    while (true)
                    {
                        try
                        {
                            if (!dirIterator.MoveNext()) // Throws if directory is not accessible.
                                break;
                        }
                        catch { break; }
                        pending.Push(dirIterator.Current);
                    }
                }
            }
        }
    }
