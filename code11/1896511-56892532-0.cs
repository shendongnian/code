C#
public class Entry
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal MoneyAmount { get; set; }
    public virtual Account Account { get; set; }
    public virtual Category Category { get; set; }
    public string CreatedTimestamp { get; set; }
}
To this:
C#
 public class Entry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal MoneyAmount { get; set; }
        public int AccountId { get; set; }
        public int CategoryId { get; set; }
        public string CreatedTimestamp { get; set; }
    }
And everything seems to work fine now. C# does its magic and picks AccountId and CategoryId as foreign keys.
