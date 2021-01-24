    public interface IGeneric<TEntity, TKey, in Tdto> where TEntity: BaseEntity<TKey>
    {
    	IQueryable<TEntity> GetAll();
    	IQueryable<DTO> GetAll<DTO>();
    
    	//void Add(TEntity newItem);
    	//void AddRange(List<TEntity> newItems);
    
    	bool Update(TEntity updateItem);
    	void UpdateRange(List<TEntity> updateItems);
    
    	bool Delete(TKey id);
    	bool DeleteRange(List<TEntity> removeItems);
    
    	TEntity GetById(TKey id);
    }
