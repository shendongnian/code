    using Dapper.Contrib.Extensions;
    
    [Table("table_name")]
    public class SquawkRegisterPMEEntity
    {
        [ExplicitKey]
        public string SomeKey { get; set; }
        [Key]
        public int SomeOtherKey{ get; set; }
        public string SomeProperty { get; set; }
        public string SomeProperty1 { get; set; }
    }
