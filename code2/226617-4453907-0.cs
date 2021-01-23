    public abstract class EntityRepositoryBase<TEntity, TMapper>
        where TMapper : IMapper<TEntity>
    {
        public virtual TEntity Get(int id)
        {
            List<TEntity> entities;
            using (var command = new SqlCommand {CommandText = CommandText})
            {
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                entities = new List<TEntity>();
                using (var reader = Database.ExecuteQuery(command, ConnectionName.Dev))
                {
                    while (reader.Read())
                    {
                        var mapper = Mapper;
                        entities = mapper.MapAll(reader);
                    }
                }
            }
            return entities.First();
        }
        protected abstract string CommandText { get; }
        protected abstract TMapper Mapper { get; }
    }
    public class OrganisationEntityRepository :
        EntityRepositoryBase<OrganisationEntity, OrganisationEntityMapper<OrganisationEntity>>
    {
        protected override string CommandText
        {
            get { return @"SELECT t.Id, t.Description FROM Organisation t Where t.Id = @Id"; }
        }
        protected override OrganisationEntityMapper<OrganisationEntity> Mapper
        {
            get { throw new NotImplementedException(); }
        }
    }
    public class CustomerEntityRepository : EntityRepositoryBase<CustomerEntity, CustomerEntityMapper<CustomerEntity>>
    {
        protected override string CommandText
        {
            get { return @"SELECT t.Id, t.Description FROM Customer t Where t.Id = @Id"; }
        }
        protected override CustomerEntityMapper<CustomerEntity> Mapper
        {
            get { throw new NotImplementedException(); }
        }
    }
