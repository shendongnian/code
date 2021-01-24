 public class Category : Entity
    {
        public virtual string Name { get; set; }
                public virtual IList<Category> SubCategories { get; set; } = new List<Category>();
        public virtual long? ParentId { get; set; }
        
        public Category()
        { }
        public Category(Category category)
        {
            SubCategories = new List<Category>();
        }
    }
And the mapping like so:
 public class CategoryMap : NHibernateMap<Category>
    {
        public CategoryMap()
        {
            Map(x => x.Name);
            Map(x => x.ParentId);
            HasMany(x => x.SubCategories).Cascade.AllDeleteOrphan();
        }
    }
In my service I can then do the following:
public Category CreateCategory(CreateCategoryModel model)
        {
            var category = new Category
            {
                Name = model.Name,
            };
            if (model.ParentCategory == null)
            {
                category.ParentId = null;
                return category;
            }
            var parent = Get(model.ParentCategory.Id);
            parent.SubCategories.Add(category);
            _categoryRepository.SaveOrUpdate(parent);
            category.ParentId = model.ParentCategory.Id;
            return category;
        }
