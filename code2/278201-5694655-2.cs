    static void Main()
    {
        var q = Enumerable.Range(1, 5).Select(x =>
        {
            if (x % 2 == 0)
            {
                throw new Exception();
            }
            return x;
        });
        using (var enumerator = q.GetEnumerator())
        {
            while (true)
            {
                try
                {
                    bool hasNext = enumerator.MoveNext();
                    if (!hasNext)
                    {
                        break;
                    }
                    Console.WriteLine(enumerator.Current);
                }
                catch (Exception ex)
                {
                    // TODO: do something with the exception here
                }
            }
        }
    }
