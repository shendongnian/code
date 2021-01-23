    public static ulong GetUInt64Hash(HashAlgorithm hasher, string text)
        {
            using (hasher)
            {
                var bytes = hasher.ComputeHash(Encoding.Default.GetBytes(text));
                return Enumerable.Range(0, bytes.Length / 8) //8 bytes in an 64 bit interger
                    .Select(i => BitConverter.ToUInt64(bytes, i * 8))
                    .Aggregate((x, y) => x ^ y);
            }
        }
