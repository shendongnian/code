    public async Task<decimal> SearchPDFAsync(string searchTerm, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            decimal result = 0;
            // Loop for a defined number of iterations
            for (int i = 0; i < 1000; i++)
            {
                // HERE IS WHERE I'M TOLD THERE IS AN UNHANDLED EXCEPTION
                if (cancellationToken.IsCancellationRequested) throw new TaskCanceledException(task);
                // Do something that takes times like a Thread.Sleep in .NET Core 2.
                await Task.Delay(10);
                result += i;
            }
            return result;
        });
    }
