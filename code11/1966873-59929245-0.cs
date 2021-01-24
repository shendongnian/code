`
public class CodeLists
{
	public Guid Id { get; set; }
	public Guid? ClassificationId { get; set; }
	public Guid? DescriptionId { get; set; }
	public Guid NameId { get; set; }
	public Guid? OwnerId { get; set; }
}
`
`ClassificationId` and `OwnerId` are not nullable in your `CodeLists` class implmementation but is nullable in the Db
