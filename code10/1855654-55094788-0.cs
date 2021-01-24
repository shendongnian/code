struct B
{
    public int b_a;
}
struct A
{
    public int sizeB;
    public B[] b;
}
The first being a BinaryWriter. This can be faster if your structure does not have a lot of fields.
static byte[] ConvertToByte(A a)
{
    using (var ms = new MemoryStream())
    using (var writer = new BinaryWriter(ms))
    {
        writer.Write(a.sizeB);
        foreach (var b in a.b)
            writer.Write(b.b_a);
        return ms.ToArray();
    }
}
The other to use marshalling like you were but explicitly looping through the array.
static byte[] ConvertToByte(A a)
{
    var bStructSize = Marshal.SizeOf<B>();
    var size = bStructSize * a.b.Length;
    var arr = new byte[size + 4];
    var ptr = Marshal.AllocHGlobal(size);
    for (int i = 0; i < a.b.Length; i++)
        Marshal.StructureToPtr(a.b[i], ptr + i * bStructSize, true);
    Marshal.Copy(ptr, arr, 4, size);
    Array.Copy(BitConverter.GetBytes(a.sizeB), arr, 4);
    return arr;
}
