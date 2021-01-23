    public CategoryViewModel GetSingle( Expression<Func<CategoryViewModel, bool>> where)
            {
                Expression<Func<DAL.EntityModels.Category, CategoryViewModel>> converter =
                    c => ToBll(c);
                
                var param = Expression.Parameter(typeof(DAL.EntityModels.Category), "category");
                var body = Expression.Invoke(where, Expression.Invoke(converter, param));
                var lambda = Expression.Lambda<Func<DAL.EntityModels.Category, bool>>(body, param);
    
                return  (CategoryViewModel )_categoryRepository.GetSingle(lambda);
     
            }
    //..............
    public T GetSingle(Expression<Func<T, bool>> where)
            {
                return this.ObjectSet.Where(where).FirstOrDefault<T>();
            }
