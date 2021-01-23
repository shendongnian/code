public static class MicrosoftStreamExtensions
{
    public static IRandomAccessStream AsRandomAccessStream(this Stream stream)
    {
        return new RandomStream(stream);
    }
}
class RandomStream : IRandomAccessStream
{
    Stream internstream;
    public RandomStream(Stream underlyingstream)
    {
        internstream = underlyingstream;
    }
    public IInputStream GetInputStreamAt(ulong position)
    {
        //THANKS Microsoft! This is GREATLY appreciated!
        internstream.Position = (long)position;
        return internstream.AsInputStream();
    }
    public IOutputStream GetOutputStreamAt(ulong position)
    {
        internstream.Position = (long)position;
        return internstream.AsOutputStream();
    }
    public ulong Size
    {
        get
        {
            return (ulong)internstream.Length;
        }
        set
        {
            internstream.SetLength((long)value);
        }
    }
    public bool CanRead
    {
        get { return this.internstream.CanRead; }
    }
    public bool CanWrite
    {
        get { return this.internstream.CanWrite; }
    }
    public IRandomAccessStream CloneStream()
    {
        throw new NotSupportedException();
    }
    public ulong Position
    {
        get { return (ulong)this.internstream.Position; }
    }
    public void Seek(ulong position)
    {
        this.internstream.Seek((long)position, SeekOrigin.Begin);
    }
    public void Dispose()
    {
        this.internstream.Dispose();
    }
    public Windows.Foundation.IAsyncOperationWithProgress<IBuffer, uint> ReadAsync(IBuffer buffer, uint count, InputStreamOptions options)
    {
        return this.GetInputStreamAt(this.Position).ReadAsync(buffer, count, options);
    }
    public Windows.Foundation.IAsyncOperation<bool> FlushAsync()
    {
        return this.GetOutputStreamAt(this.Position).FlushAsync();
    }
    public Windows.Foundation.IAsyncOperationWithProgress<uint, uint> WriteAsync(IBuffer buffer)
    {
        return this.GetOutputStreamAt(this.Position).WriteAsync(buffer);
    }
}
