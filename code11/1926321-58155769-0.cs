   public class ProductImage : ImageProp, DBEntity
    {
        [Column("Name", TypeName = "nvarchar(200)"), Required, Display(Name = "שם"), MaxLength(200)]
        public string Name { get; set; }
        public Product Product { get; set; } 
        [Required]
        public int ProductId { get; set; }
    }
so the problem was this line:
  public Product Product { get; set; } 
which apparently created a unique key for ProductId field in the data base table.
when i tried to add multiple ProductImages with the same ProductId, i got an sql exception that said i cannot insert duplicate value for ProductId.
removing this line solved the problem.
