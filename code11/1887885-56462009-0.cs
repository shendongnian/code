 c#
ArraySegment<byte> segment = default;
bool leased = false;
try
{
    if (!MemoryMarshal.TryGetArray<byte>(memory, out segment))
    {
        var arr = ArrayPool<byte>.Shared.Rent(memory.Length);
        memory.CopyTo(arr);
        segment = new ArraySegment<byte>(arr, 0, memory.Length);
        leased = true;
    }
    using (var ms = new MemoryStream(segment.Array, segment.Offset, segment.Count))
    {
        // ... your usage goes here!
        using (var xmlReader = XmlReader.Create(ms))
        {
            return XElement.Load(xmlReader);
        }
    }
}
finally
{
    if (leased) ArrayPool<byte>.Shared.Return(segment.Array);
}
The alternative is to create a new `Stream` implementation that works against `Memory<byte>`. That's a lot of work.
