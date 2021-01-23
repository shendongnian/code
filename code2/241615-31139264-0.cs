    /// <summary>
    /// Compares two ip addresses.
    /// http://stackoverflow.com/questions/4785218/linq-lambda-orderby-delegate-for-liststring-of-ip-addresses
    /// </summary>
    public class IpComparer : IComparer<IPAddress>
    {
        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// 
        /// <returns>
        /// A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the following table.
        /// Value Meaning Less than zero<paramref name="x"/> is less than <paramref name="y"/>.
        /// Zero<paramref name="x"/> equals <paramref name="y"/>.
        /// Greater than zero <paramref name="x"/> is greater than <paramref name="y"/>.
        /// </returns>
        /// <param name="x">The first object to compare.</param><param name="y">The second object to compare.</param>
        public int Compare(IPAddress x, IPAddress y)
        {
            if (ReferenceEquals(x, null))
            {
                throw new ArgumentNullException("x");
            }
            if (ReferenceEquals(y, null))
            {
                throw new ArgumentNullException("y");
            }
            byte[] bytesOfX = x.GetAddressBytes();
            byte[] bytesOfY = y.GetAddressBytes();
            return StructuralComparisons.StructuralComparer.Compare(bytesOfX, bytesOfY);
        }
    }
