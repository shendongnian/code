    public class CurrencyConfiguration : EntityTypeConfiguration<Currency>
        {
            public CurrencyConfiguration()
            {
                this.ToTable("Conv", "Ref");           
            }
        }
