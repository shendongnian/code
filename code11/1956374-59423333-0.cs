    public struct CustomMailAddress
    {
        public string Address { get; private set; }
        public string DisplayName { get; private set; }
        public bool IsFullAddress { get; private set; }
        public CustomMailAddress(string address)
        {
            this.Address = address;
            this.DisplayName = String.Empty;
            this.IsFullAddress = address.IndexOf('@') >= 0;
        }
        public CustomMailAddress(MailAddress address)
        {
            this.Address = address.Address;
            this.DisplayName = address.DisplayName;
            this.IsFullAddress = true;
        }
        public override bool Equals(object obj)
        {
            if ((obj is CustomMailAddress y))
            {
                return this.IsFullAddress ? this.Address.EndsWith(y.Address) : y.Address.EndsWith(this.Address);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Address.GetHashCode();
        }
    }
