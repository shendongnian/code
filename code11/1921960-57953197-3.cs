    public abstract class RepositoryBase<T> where T : class
    {
        public virtual async Task Update(T entity)
        {            
            dbSet.Attach(entity);
            shopContext.Entry(entity).State = EntityState.Modified;
            await shopContext.SaveChangesAsync();
        }
    }
    public class CategoryService : ICategoryService
    {    
        public async Task UpdateCategory(Categories category)
        {
            return await _categoryRepository.Update(category);
        }
    }
