    public abstract class Letter
    {
        public string Name { get; set; }
    }
    public class LetterMap : EntityTypeConfiguration<Letter>
    {
        public LetterMap()
        {
            HasKey(l => l.Id);
        
            //assuming discriminator column is "Type"
            Map<A>(a => a.Requires("Type").HasValue<byte>(1));
            Map<B>(b => b.Requires("Type").HasValue<byte>(2));
        }
    }
    public class BMap : EntityTypeConfiguration<B>
    {
        public LetterMap()
        {
              HasOptional(b => b.description)
                WithMany()
                HasForeignKey(b=> b.descriptionId);
        }
    }
