    public class IPComparer : IComparer<IPAddress>
    {
        public int Compare(IPAddress x, IPAddress y)
        {
            if (ReferenceEquals(x, null))
                throw new ArgumentNullException("x");
            if (ReferenceEquals(y, null))
                throw new ArgumentNullException("y");
            return BitConverter.ToUInt32(x.GetAddressBytes().Reverse().ToArray(),0)
                .CompareTo(BitConverter.ToUInt32(y.GetAddressBytes().Reverse().ToArray(),0));
        }
    }
