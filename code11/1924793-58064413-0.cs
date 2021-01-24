C#
public class Application
{
     [Key] //key attribut
    public int Id { get; set; }
    public string OfficeName { get; set; }
    public Person Persons { get; set; }
}
 public class Person
 {
     [Key] //key attribut
     public int Id { get; set; }
     public string Name{ get; set; }
     public List<PersonContact> Contacts{ get; set; }
 }
 public class PersonContact
 {
     [Key] //key attribut
     public int Id { get; set; }
     public string ContactName { get; set; }
 }
