    private static async Task DoWork(CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        var gameObjects = new List<GameObject>();
        await ThreadSwitcher.ResumeUnityAsync();
        for (var i = 0; i < 25; i++)
        {
            if (token.IsCancellationRequested)
                token.ThrowIfCancellationRequested();
            await Task.Delay(125, token);
            var gameObject = new GameObject(i.ToString());
            gameObjects.Add(gameObject);
        }
    }
