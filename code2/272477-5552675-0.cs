    public class ClassAMapping : EntityTypeConfiguration<ClassA>
    {
        public ClassA()
        {
            HasKey(x => x.Id);
    
            HasOptional<ClassB>(x => x.ClassB)
                    .WithRequired()
                    .Map(x => x.MapKey("ClassBId"));
        }
    }
