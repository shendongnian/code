    public class Address
    {
       [ForeignKey("AnAddressType")]
       public int MyCrazyAnAddressTypeNumberCodeKeyId {get; set;}
       public virtual AddressType AnAddressType {get; set;}
    }
