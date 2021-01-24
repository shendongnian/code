    public void Test()
    {
        using (var disposable1 = new DisposableClass())
        {
            using (var disposable2 = new DisposableClass())
            {
                Action action = () => Console.Write($"{disposable1}{disposable2}");
            }
        }
    }
