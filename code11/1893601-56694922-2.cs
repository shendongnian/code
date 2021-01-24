    public interface IFinancialsSyncService<TEntity>
       where TEntity : IEntity
    {
      TEntity Financials { get; set; }
    }
