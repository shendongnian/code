    [Subject("Sandwich Repository CRUD")]
    public class when_a_sandwich_is_created : SandwichRepositoryContext
    {
        Establish context = () =>
        {
            sandwich = new Sandwich(ValidSandwichName);
            repository = new SandwichRepository();
        };
    
        Because of = () => { repository.Save(sandwich); };
    
        It should_find_the_created_sandwich =
            () => repository.GetSandwichByName(ValidSandwichName).ShouldNotBeNull();
    }
    
    public abstract class SandwichRepositoryContext
    {
        protected static Sandwich sandwich;
        protected const string ValidSandwichName = "Olive Le Fabulos";
        protected static SandwichRepository repository;
    }
