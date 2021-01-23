	public class Repository<T> : IRepository<T> where T : class, new()
	{
		private IEntityMapper<T> _mapper;
		
		public Repository(IEntityMapper<T> mapper)
		{
			_mapper = mapper;
		}
		public virtual T Find(string value)
		{
			SqlCommand command = new SqlCommand();
			command.CommandText = @"SELECT t.Id, t.Description FROM Organisation t Where t.Description LIKE @value";
			command.Parameters.Add("@value").Value = value + "%";
			SqlDataReader reader = Database.ExecuteQuery(command, ConnectionName.Dev);
			return FillCollection(reader);
		}
		
		public void T Get(int id)
		{
			SqlCommand command = new SqlCommand();
			command.CommandText = @"SELECT t.Id, t.Description FROM Organisation t Where t.id = @value";
			command.Parameters.Add("@value").Value = id;
			SqlDataReader reader = Database.ExecuteQuery(command, ConnectionName.Dev);
			if (!reader.Read())
				return null;
				
			T entity = new T();
			_mapper.Map(entity, reader);
			return entity;
		}
		
		protected IList<T> FillCollection(IDataReader reader)
		{
			List<T> items = new List<T>();
			while (reader.Read())
			{
				T entity = new T();
				_mapper.Map(entity, reader);
				_items.Add(entity);
			}
			return items;
		}
	}
		
		
		
	public interface IEntityMapper<T>
	{
		//row is the most generic part of a DataReader
		void Map(T entity, IDataRow row);
	}
