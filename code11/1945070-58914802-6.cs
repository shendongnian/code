    modelBuilder.Entity<AddressDto>()
                    .HasMany(b => b.CountryLocale)
                    .WithOne();
    public class AddressDto
            {
                public int Id { get; set; }
                public int CountryId { get; set; }
                public List<CountryLocaleDto> CountryLocale { get; set; }
            }
            public class CountryLocaleDto
            {
                public int Id { get; set; }
                public string Locale { get; set; }
            }
