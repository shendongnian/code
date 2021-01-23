    public static class ByteArrayExt {
        public static byte[] ToASCIIFriendlyArray(this byte[] data) {
            byte[] result = new byte[data.Length];
            for (int i=0;i<data.Length;i++)
                result[i] = b >= 0x20 || b < 0x80 ? b : '.';
            return result;
        }
    }
---
    Encoding.ASCII.GetString(data.ToASCIIFriendlyArray());
