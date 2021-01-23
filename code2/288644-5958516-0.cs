    var bytes = File.ReadAllBytes(...);
    int oldLength = bytes.Length;
    Array.Resize(ref bytes, bytes + toAppend.Length);
    Array.Copy(toAppend, 0, bytes, oldLength, toAppend.Length);
    File.WriteAllBytes(..., bytes);
