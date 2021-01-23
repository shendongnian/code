    public class AnimalMapping : ClassMap<Animal>
    {
        public AnimalMapping()
        {
            Table("Animals");
            Id(x => x.Id).GeneratedBy.Native();    
            References(x => x.AnimalsOwner);
            DiscriminateSubClassesOnColumn("AnimalType");
        }
    }
    
    public class DogMap : SubclassMap<Dog>
    {
        public DogMap()
        {
            DiscriminatorValue("DOG");
            Map(x => x.DogsProperty);
        }
    }
    
    public class CatMap : SubclassMap<Cat>
    {
        public CatMap()
        {
            DiscriminatorValue("CAT");
            Map(x => x.CatsProperty);
        }
    }
