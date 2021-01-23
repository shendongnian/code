    public class Category
    {
       public int? ParentID{get;set;}
    }
    public class CategoryRepository
    {
       public Category Get(int id)
       {
          Category result = GetFromDBAlongWithParentID(id);
       }
    
       public Category GetParent(Category child)
       {
          return child.ParentID.HasValue ? (Category)null : this.Get(child.ParentID.Value);
       }
    }
