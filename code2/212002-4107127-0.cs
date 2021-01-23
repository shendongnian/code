    public class CategoryComparer : IEqualityComparer<Category>
    {
        public bool Equals(Category a, Category b)
        {
            bool result = false;
            if( a.pk1 == b.pk1 && a.pk2 == b.pk2 && a.name == b.name)
                result = true;
            return result;    
        }
        
        public int GetHashCode(Category category)
        {        
            if (Object.ReferenceEquals(category, null)) return 0;        
            return category.pk1.GetHashCode() ^ category.pk2.GetHashCode();
        }
    }
