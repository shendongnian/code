[StructLayout(LayoutKind.Explicit)]
public struct CharUnion
{
    [FieldOffset(0)] public char UnicodeChar;
    [FieldOffset(0)] public byte AsciiChar;
}
to
[StructLayout(LayoutKind.Explicit, CharSet=CharSet.Unicode)]
public struct CharUnion
{
    [FieldOffset(0)] public char UnicodeChar;
    [FieldOffset(0)] public byte AsciiChar;
}
This is because it will default to ANSI meaning your unicode characters get automatically turned into ANSI, hence ┬ into ,
