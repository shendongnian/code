    class customerframe
    {
    public string firstName { get; set; }
     public string lastName { get; set; }
     public string city { get; set; }
     public string street { get; set; }
     public string zipcode { get; set; }
     public CustomerFiles CustomerFiles { get; set; }
    }
    
    public class CustomerFiles 
    {
    public Phone phone { get; set; }
    public Email email { get; set; }
    public Address addressinfo { get; set; }
    public Countries countryinfo { get; set; }
    
    }
