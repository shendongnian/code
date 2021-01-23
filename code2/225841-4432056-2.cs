    public class ItemFactory
    {
        private readonly IRepository<Category> repository;
        public ItemFactory(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        public SpecificItem CreateSpecificItem(object someArguments)
        {
            return new SpecificItem
            {
                 Category = this.repository.FirstOrDefault(i => 
                     i.Id == Category.IdOfCategoryForSpecificItem),
                 // additional initialization
            };
        }
    }
