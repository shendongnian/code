public class MyDto
{
    public readonly AddressDto BillingAddress;
    public readonly AddressDto ShippingAddress;
    public readonly long? Phone;
    ...
}
public class AddressDto
{
    public readonly string Country;
    public readonly string SubnationalEntity;
    ...
}
public class MyViewModel
{
    public string BillingAddressCountry { get; set; }
    public string BillingAddressSubnationalEntity { get; set; }
    public string ShippingAddressCountry { get; set; }
    public string ShippingAddressSubnationalEntity { get; set; }
    public string Phone { get; set; }
    ...
}
It worked once I changed it to the following:
public class MyDto
{
    public readonly AddressDto BillingAddress;
    public readonly AddressDto ShippingAddress;
    public readonly long? Phone;
    ...
}
public class AddressDto
{
    public readonly string Country;
    public readonly string SubnationalEntity;
    ...
}
public class MyViewModel
{
    public string AddressViewModel BillingAddress { get; set; }
    public string AddressViewModel ShippingAddress { get; set; }
    public string Phone { get; set; }
    ...
}
public class AddressViewModel
{
    public string Country { get; set; }
    public string SubnationalEntity { get; set; }
}
