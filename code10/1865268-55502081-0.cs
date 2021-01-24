    public class ContactConfig: EntityTypeConfiguration<Contact>
     {
        public ContactConfig()
        {
            HasKey(c => c.ID);
            Property(c => c.Contact1 )
                .IsRequired();
            Property(c => c.Email )
                .IsRequired();
            Property(c => c.ContactTitle )
                .IsRequired();
            //Here is the secret
            HasRequired(c => c.Costumer)
                .WithMany(c => c.Contact)
                .HasForeignKey(c => c.CustomerID);
      }
    }
