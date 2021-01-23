    public static class ListExtensions 
    {
        public static bool TryAdd(this IList<IAddress> list, IAddress applicationAddress)
        {
            if (!list.Any(x => x.AddressType != applicationAddress.AddressType))
            {
                list.Add(applicationAddress);
                return true;
            }
            return false;
        }
    }
