    public class BaseClass
    {
        public int Id {get; set;}
    }
    public class DerivedClass : BaseClass
    {
        public string Data {get; set;}
    }
    public class BaseConfiguration : EntityTypeConfiguration<BaseClass>
    {
        Key(k=>k.Id);
        Table("BaseTable"); // uses table "BaseTable" in the database
    }
    public class DerivedConfiguration : EntityTypeConfiguration<DerivedClass>
    {
        Property(p=> BaseClassId = p.Id); // overrides column name of base class ID field
        Table("DerivedTable");
    }
