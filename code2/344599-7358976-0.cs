    public static byte[] ReadToEnd(this Stream s) {
        using(var ms = new MemoryStream()) {
            s.CopyTo(ms);
            return ms.ToArray();
        }
    }
