    public partial class TRADELINE
        {
            [StringLength(36)]
            [Column(TypeName = "char")] // This line got added later
            public string ID { get; set; }
        }
