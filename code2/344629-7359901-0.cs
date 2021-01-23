    public class Contact{
      public string Name {get;set;}
      public string Telephone {get;set;}
    }
    public class PersonalInfo{
      public Contact Contact {get;set;}
      public PersonalInfo(){
        this.Contact = new Contact();
      }
    }
    var info = new PersonalInfo();
    info.Contact.Name = "name";
    info.Contact.Telephone = "2323232";
;)
