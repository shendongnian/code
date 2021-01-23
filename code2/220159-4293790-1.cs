    private IEnumerable<int> Test()
    {
        using (new Disposable("outer"))
        {
            using (new Disposable("inner"))
            {
                for (int i = 0; i < 10; i++)
                {
                    yield return i;
                }
            }
        }
    }
    ...
    foreach (int i in Test())
    {
        Console.WriteLine("item {0}", i);
    }
