 c#
static void Main()
{
    Span<byte> data = stackalloc byte[20];
    GetBytes(0, data, 0);
    GetBytes(123.45F, data, 4);
    GetBytes(123.45D, data, 8);
}
static unsafe void GetBytes(float value, Span<byte> buffer, int offset)
    => MemoryMarshal.Cast<byte, float>(buffer.Slice(offset))[0] = value;
static unsafe void GetBytes(double value, Span<byte> buffer, int offset)
    => MemoryMarshal.Cast<byte, double>(buffer.Slice(offset))[0] = value;
---
If you don't want to allocate new arrays all the time (which is what `GetBytes` does), you can use `unsafe` code to write to a buffer directly:
    static void Main()
    {
        byte[] data = new byte[20];
        GetBytes(0, data, 0);
        GetBytes(123.45F, data, 4);
        GetBytes(123.45D, data, 8);
    }
    static unsafe void GetBytes(float value, byte[] buffer, int offset)
    {
        fixed (byte* ptr = &buffer[offset])
        {
            float* typed = (float*)ptr;
            *typed = value;
        }
    }
    static unsafe void GetBytes(double value, byte[] buffer, int offset)
    {
        fixed (byte* ptr = &buffer[offset])
        {
            double* typed = (double*)ptr;
            *typed = value;
        }
    }
