abstract class Entity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}
/// <summary>Definition of all 'available' types of card</summary>
/// <remarks>It might make sense to refer or rename this table to CardType</remarks>
class Card : Entity
{
    public string Name { get; set; }
    public string Set { get; set; }
}
class User : Entity
{
    public string Name { get; set; }
    public virtual List<Collection> Collections { get; set; } = new HashSet<Collection>();
}
class Collection : Entity
{
    public int UserId { get;set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    public string Name { get; set; }
    public virtual List<CollectionCard> Cards { get; set; } = new HashSet<CollectionCard>();
}
class CollectionCard : Entity
{
    public int CollectionId { get;set; }
    [ForeignKey(nameof(CollectionId))]
    public virtual Collection Collection { get; set; }
    
    public int CardId { get; set; }
    [ForeignKey(nameof(CardId))]
    public virtual Card Card { get; set; }
}
This structure is useful in card game type of scenarios because you can easily import/export the card definitions list without causing too much adverse problems with the rest of the dataset.
> Notice that I have added value to your `Entity` base class by decorating the `Id` field with the `KeyAttribute`. While EF works well from a `Convention-Only` approach, I recommend a hybrid between using attribute notation especially for all _Foreign_ and _Primary_ key configuration, and allowing model conventions to manage less important structural defintions.
>> Reserve fluent model notations to scenarios where the attribute notation is not viable or the conventions are not working for you. 
>> - this advise is based on the reality that it is hard to find/maintain fluent notations down the track as your model grows, attirbute notation is contained with each field, which is the primary reference point when you don't know what a field does in your model.
  [1]: https://docs.microsoft.com/en-us/ef/core/modeling/shadow-properties
  [2]: https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api#no-foreign-key-property
