    [OperationContract]
    [WebGet(UriTemplate = "people/driversLicense/{driversLicense}")]
    string GetPersonByLicense(string driversLicense);
    [OperationContract]
    [WebGet(UriTemplate = "people/ssn/{ssn}")]
    string GetPersonBySSN(string ssn);
