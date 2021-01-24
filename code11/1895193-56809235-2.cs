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
  [1]: https://weblogs.asp.net/manavi/inheritance-mapping-strategies-with-entity-framework-code-first-ctp5-part-2-table-per-type-tpt
