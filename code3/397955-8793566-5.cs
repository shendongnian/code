    unsafe string ReplaceInvalidCodePoints(string aString, char replacement)
    {
        if (char.IsHighSurrogate(replacement) || char.IsLowSurrogate(replacement))
            throw new ArgumentException("Replacement cannot be a surrogate", "replacement");
        byte[] utf32String = Encoding.UTF32.GetBytes(aString);
        fixed (byte* d = utf32String)
        fixed (byte* s = Encoding.UTF32.GetBytes(new[] { replacement }))
        {
            var data = (UInt32*)d;
            var substitute = *(UInt32*)s;
            for(var p = data; p < data + ((utf32String.Length) / sizeof(UInt32)); p++)
            {
                if (!(IsValidCodePoint(*p))) *p = substitute;
            }
        }
        return Encoding.UTF32.GetString(utf32String);
    }
