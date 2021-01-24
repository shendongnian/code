    List<ContactModel> contacts = ReadContacts();
    ContactModel contactVm;
    for (int i = 0; i < contacts.Count; i++)
    {
        contactVm = contacts[i];
        Console.WriteLine("Contact is : " + contactVm.FamilyName);
        Console.WriteLine("Contact is : " + contactVm.GivenName);
        Console.WriteLine("Contact is : " + contactVm.PhoneNumbers);
    }
