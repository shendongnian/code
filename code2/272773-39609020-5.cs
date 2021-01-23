    public class PhoneMap: ExtendedEntityTypeConfiguration<Phone>
        {
            public PhoneMap()
            {
                 // Primary Key
                 this.HasKey(m => m.Id);
                  …
                 // Unique keys
                 this.HasUniqueKey(m => new { m.Prefix, m.Digits });
            }
        }
