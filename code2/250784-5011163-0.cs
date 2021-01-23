    class ContactInfo
    {
       string Name;
       string TelephoneNumber;
    }
    Dictionary<string, ICollection<ContactInfo>> addressAndPeopleLivingThere = 
        new Dictionary<string, ICollection<ContactInfo>>();
    addressAndPeopleLivingThere.Add("1 Some Street", new List<ContactInfo>());
    addressAndPeopleLivingThere["1 Some Street"].Add(new ContactInfo { Name = "Name", TelephoneNumber = "000-000-0000" });
