    public interface IOrderRepository : IRepository<OrderDTO>
    {
        OrderDTO Add(OrderDTO order); 
        Task<OrderDTO> GetAsync(int orderId);
    }
    public interface IAdaptable<TEntity, TDTO>
    {
        TDTO ToDTO(TEntity entity);
        TEntity ToEntity(TDTO entityDTO, TEntity entity);
    }
