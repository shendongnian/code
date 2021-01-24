 c#
static void Main()
{
    static string ByteHex(int value) => (value & 0xFF).ToString("X2");
    int a = 50;
    Console.WriteLine("0x" + ByteHex(a >> 24));
    Console.WriteLine("0x" + ByteHex(a >> 16));
    Console.WriteLine("0x" + ByteHex(a >> 8));
    Console.WriteLine("0x" + ByteHex(a));
}
In more nuanced cases, there is a new-ish `BinaryPrimitives` type that is your friend:
 c#
int a = 50;
Span<byte> span = stackalloc byte[4];
BinaryPrimitives.WriteInt32BigEndian(span, a);
// now access span[0] - span[3]
This is usually preferable to `BitConverter` which a: is allocation-heavy, and b: is awkward re endianness (you need to flip on `BitConverter.IsLittleEndian`)
