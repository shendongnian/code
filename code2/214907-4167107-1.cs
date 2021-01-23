    public interface IPerson {
        string Name
        string Address
        string StateProvince
        string ZipPostalCode
        string Country
        long PhoneNumber
    }
    public interface ICompany {
        string CreditTerm
        string BillingAddress
        string ShippingAddress
        string ContactName
        long ContactPhoneNumber
        long FaxNumber
    }
    public class Customer : IPerson, ICompany {
        // Properties implementations here.
    }
