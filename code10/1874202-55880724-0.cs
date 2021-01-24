    public virtual List<TEntity> GetByIds(int[] ids)
    {
    	var idName = _context.Model.FindEntityType(typeof(TEntity))
    		.FindPrimaryKey().Properties.Single().Name;
    	return Entities
    		.Where(x => ids.Contains(EF.Property<int>(x, idName)))
    		.ToList();
    }
 
