        public class EpiDB : DbContext
        {
            public DbSet<Tran> PartTran { get; set; }
        }
        [Table("PartTran", Schema = "ERP")]
        public class Tran
        {
            public int TranNum { get; set; }
            public string TranReference { get; set; }
            public string PartNum { get; set; }
        }
