    public class ContactDetails
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Village { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ContactDetails)) return false;
            return Equals((ContactDetails) obj);
        }
        public bool Equals(ContactDetails other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Name, Name) && Equals(other.Address, Address);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0)*397) 
                    ^ (Address != null ? Address.GetHashCode() : 0);
            }
        }
    }
