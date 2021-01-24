C#
    [KnownType(typeof(Sale))]
    [KnownType(typeof(Restaurant))]
    [KnownType(typeof(Employee))]
    [DataContract]
    public class SomeObject {
	
    }
    [DataContract(Name = "Sale", Namespace="")]
    public class Sale : SomeObject
    {
       //methods + properties + variables
    }
    
    [DataContract(Name = "Restaurant", Namespace="")]
    public class Restaurant : SomeObject
    {
        //methods + properties + variables   
    }
    [DataContract(Name = "Employee", Namespace="")]
    public class Employee: SomeObject
    {
        //methods + properties + variables   
    }
and then use the dictionary as
    Dictionary<string, SomeObject> dict = new Dictionary<string, SomeObject>();
