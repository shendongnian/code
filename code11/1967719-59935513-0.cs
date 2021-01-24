 c#
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
static class P
{
    static void Main()
    {
        var obj = new SystemInfo();
        var bytes = AsBytes(ref obj);
        Console.WriteLine(bytes.Length); // 40
    }
    static Span<byte> AsBytes<T>(ref T value)
        => MemoryMarshal.CreateSpan(
            ref Unsafe.As<T, byte>(ref value),
            Unsafe.SizeOf<T>());
}
public readonly struct SystemInfo
{
    public readonly ulong OemId;
    public readonly ulong PageSize;
    public readonly ulong ActiveProcessorMask;
    public readonly ulong NumberOfProcessors;
    public readonly ulong ProcessorType;
}
