        public AddressCollection GetAddressList(IList<Address> addresses)
        {
            MemberModel.AddressCollection objAddresses = new MemberModel.AddressCollection();
            foreach (var item in addresses)
            {
                objAddresses.Add(item);
            }
            return objAddresses;
        }
