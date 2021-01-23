    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Goffsoft2011
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Contact Contact = new Contact();
                    Contact.Country = "DK";
                    if (Contact.Country == "DK")
                    {
                        AddressDK _address = new AddressDK();
                        _address.Street = "MyStreat";
                        Contact.Address = _address;
    
                    }
                    else
                    {
                        AddressInternational _address = new AddressInternational();
                        _address.Address1 = "First line in foreign address";
                        Contact.Address = _address;
                    }
    
                    Console.WriteLine(((AddressDK)Contact.Address).Street);
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
    
                }
    
            }
    
        }
    
        public class Contact
        {
            public string FirstName = "";
            public string LastName = "";
            public string Country = "DK";
            public Address Address = null;
        }
    
        public class Address
        {
        }
    
        public class AddressDK : Address
        {
            public String Street = "";
            public String HouseNumber = "";
            public string ZipCode = "";
            public String City = "";
        }
        public class AddressInternational : Address
        {
            public string Address1 = "";
            public string Address2 = "";
            public string Address3 = "";
            public string Address4 = "";
            public string Address5 = "";
        }
    
    
    
    }
