public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
    public abstract bool IsChildOfBee();
    public abstract string GetDisplayName();
}
When you add a child entity override those methods:
public class EntityCee :BaseEntity
{
    public string Name { get; set; }
    public override string GetDisplayName()
    {
        return "Entity Cee";
    }
    public override bool IsChildOfBee()
    {
        return true;
    }
}
Before you delete entity B, check the associated entities:
var errors = new List<string>();
var entityBeeToDelete = _exampleRepository.GetEntityBee(1);
var associatedEntities = _exampleRepository.GetAssociatedEntities(entityBeeToDelete);
foreach(var e in associatedEntities)
{
    errors.Add($"{entityBeeToDelete.GetDisplayName()} has some {e} records associated with it. Please delete those before deleting {entityBeeToDelete.GetDisplayName()}");
}
Here is the function that checks for associated children:
public List<string> GetAssociatedEntities(EntityBee bee)
{
    var types = new List<string>();
    foreach (var entityType in this.Model.GetEntityTypes())
    {
        var clr = entityType.ClrType;
        var tableName = entityType.Relational().TableName;
        BaseEntity instance = (BaseEntity)Activator.CreateInstance(clr);
        var isChildOfBee = instance.IsChildOfBee();
        if(isChildOfBee)
        {
            var query = $"select top(1) * from EntityBees where Id IN (select EntityBeeId from {tableName} where EntityBeeId = {bee.Id})";
            
            var eB = this.EntityBees.FromSql(query).FirstOrDefault();
            if(eB != null)
            {
                types.Add(instance.GetDisplayName());
            }
        }
    }
    return types;
}
 
