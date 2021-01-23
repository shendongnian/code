    private static Task<string> EncryptChunk( byte[] buffer, CryptoEngine c )
    {
        buffer = buffer.ToArray(); // Copy the data
        var tcs = new TaskCompletionSource<string>();
        Task.Factory.StartNew( () =>
        {
            tcs.SetResult( c.Encrypt( buffer ) );
        } );
        return tcs.Task;
    }
