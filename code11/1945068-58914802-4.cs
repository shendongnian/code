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
            public int AddressDtoId {get; set;}
            public AddressDto Address {get; set;}
        }
    
       modelBuilder.Entity<CountryLocaleDto>()
                    .HasOne(p => p.Address)
                    .WithMany(b => b.CountryLocale);
