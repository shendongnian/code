        public class EpiDB : DbContext
        {
            public DbSet<Tran> PartTran { get; set; }
        }
        [Table("PartTran", Schema = "ERP")]
        public class Tran
        {
            [Key] // Is this your primary key field?
            public int TranNum { get; set; }
            public string TranReference { get; set; }
            public string PartNum { get; set; }
        }
