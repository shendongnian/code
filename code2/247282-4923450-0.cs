    public interface ICategoryRepository
    {
        void Add(Category category);
        void Remove(Category category);
        List<Category> GetAll(int parentId = 0);
        Category GetRoot();
        Category Get(int id);
    }
