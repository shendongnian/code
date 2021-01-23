    Dictionary<string,string> contactInfo = new Dictionary<string,string>();
    public void ImportContact()
    {
        ...
        // for each fieldName and fieldValue from your table
        contactInfo.Add(fieldName, fieldValue);
        ...
        // check that all standard fields are present, if desired
    }
    public string FirstName
    {
        get { return contactInfo["FirstName"]; }
    }
