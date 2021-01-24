public virtual CashFlow CashFlow { get; set; }
Category should be 
public class Category
{
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// <remarks> Is Indexed with CashflowId </remarks>
        /// </summary>
        [MaxLength(32)]
        [Required]
        public string Name { get; set; }
        [Required]
        [Index("IX_NameCashFlowId", 1, IsUnique = true)]
        public int CashFlowId { get; set; }
        [Index("IX_NameCashFlowId", 1, IsUnique = true)]
        public CashFlow CashFlow { get; set; }
}
With this setup `modelBuilder.Entity<Category>().HasKey` is not needed.
