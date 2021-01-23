    static class Contracted
    {
        byte[] ToArrayContracted(this MemoryStream s)
        {
            Contract.Requires(s != null);
            Contract.Ensures(Contract.Result<byte[]>() != null);
            var result = s.ToArray();
            Contract.Assume(result != null);
            return result;
        }
    }
