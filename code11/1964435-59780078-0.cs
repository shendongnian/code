            public class MyType
             {
               [Column("StatusId")]
               public Nullable<AccountPaymentType> Status{ get; set; }
             }
             modelBuilder
            .Entity<MyType>()
            .Property(e => e.Status)
            .HasDefaultValue(AccountPaymentType.[YOUR_DEFAULT_VALUE])
            .HasConversion(new EnumToNumberConverter<Enum.Status, int>());
