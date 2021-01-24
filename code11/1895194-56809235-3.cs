c#
    public class Rider
    {
       public int ID { get; set; }
       public virtual DerivedStatus derivedStatus { get; set; }
    }
    public class BaseStatus
    {
        [Key]
        public int ID { get; set; }
        public bool? Married { get; set; }
    }
    public class DerivedStatus : BaseStatus
    {
        public bool? HomeOwnership { get; set; }
    }
DbContext remains the same as before. Having tested this, this also works for TPT, you just need to add data annotations to make Entity created separate tables. 
UPDATE: After some more testing, I have found that you can use Foreign Key and navigational properties on the base class but that you need to supplement the data annotations with Fluent API as I can't seem to get it to work on it's own. The Fleunt API I used was:
`c# 
modelBuilder.Entity<BaseStatus>()
                .HasRequired(e => e.Rider)
                .WithOptional(e => e.DerivedStatus)
                .WillCascadeOnDelete(true);
`
  [1]: https://weblogs.asp.net/manavi/inheritance-mapping-strategies-with-entity-framework-code-first-ctp5-part-2-table-per-type-tpt
