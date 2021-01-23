    public class MatchCompanyRequest
    {
        Address Address {get;set;}
    }
    
    public class MatchCompanyRequestDTO
    {
        public string Name {get;set;}
        public AddressDTO Address {get;set;}
    }
    
    public class AddressDTO
    {
        ....
    }
