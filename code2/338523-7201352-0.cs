    public interface ISpecification<TEntity>
    {
        Expression<Func<TEntity, bool>> Predicate { get; }
    }
    public class CanBorrowBooksSpec : ISpecification<Customer>
    {
        Expression<Func<Customer, bool>> Predicate 
        { 
           get{ return customer => customer.HasLibraryCard
                  && !customer.UnpaidFines.Any()} 
        }
    }
