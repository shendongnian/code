    public class DogovorStatusConfiguration : EntityTypeConfiguration<DogovorStatus> 
    {
        HasKey(v => v.StatusKey);
    }
    public class DogovorConfiguration : EntityTypeConfiguration<Dogovor>
    {
        HasKey(v => v.Key);
        Property(v => v.Key)
            .IsRequired()
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
            .HasColumnName("DG_Key");
        Property(v => v.Name)
            .IsRequired()
            .HasColumnName("DG_Name");
        HasOne(v => v.Status)
            .WithOne(s => s.Dogovor)
            .HasForeignKey<DogovorStatus>(s => s.StatusKey);
    }
