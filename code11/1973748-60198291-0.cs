        [Table("#tempAddress")]
        public class AddressTempTable : ITempTable
        {
            [Key]
            [TempFieldTypeAttribute("int")]
            public int AddressId { get; set; }
            [TempFieldTypeAttribute("varchar(200)")]
            public string StreetName { get; set; }
        }
