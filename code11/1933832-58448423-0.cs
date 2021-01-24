//example
public class EntityA
{
    [Key]
    public int Id {get; set;}
    public string Property {get; set;} //Property you want to add [attribute] but not working
    
    [AttributeYouWantToAdd]
    public string PropertyWithAttribute {get; set;}
}
Second, build the migration. In your migration, add this after your `AddColumn`
Sql("Update Table Set PropertyWithAttribute = Property");
Third, drop previous property, add migration again.
 
Fourth, add the Property again with proper name and attribute then add migration again.
Then same, after the `AddColumn`
Sql("Update Table Set Property = PropertyWithAttribute")
then drop `PropertyWithAttribute`, add migration
