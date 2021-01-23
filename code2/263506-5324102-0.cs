    public static class ProductSpecifications{
         public static readonly Specification<Product> IsOnSale = new Specification<Product>(x => !x.IsDiscontinued && x.UnitsInStock > 0);  
    }
    public class Specification<TEntity> : ISpecification<TEntity>
    {
        public Specification(Expression<Func<TEntity, bool>> predicate)
        {
            _predicate = predicate;
        }
        public bool IsSatisfiedBy(TEntity entity)
        {
            return _predicate.Compile().Invoke(entity);
        }
        private Expression<Func<TEntity, bool>> _predicate;
        public Expression<Func<TEntity,bool>> Predicate{ 
             get{ return _predicate; }
        }
    }
