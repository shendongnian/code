    public class CategoryRepository : ICategoryRepository {
        private readonly LaundryManagementSystemEntities context;
        
        public CategoryRepository(LaundryManagementSystemEntities context) {
            this.context = context;
        }
    //...
