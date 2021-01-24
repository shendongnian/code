        public class PartTran
        {
            [Key, Column(Order = 1)]
            public int TranNum { get; set; }
            public string TranReference { get; set; }
            [Key, Column(Order = 2)]
            public string PartNum { get; set; }
        }
