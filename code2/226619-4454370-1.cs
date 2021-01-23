    public class OrganisationEntityRepository : EntityRepository<OrganisationEntity>
    {
        public OrganisationEntityRepository(IEntityMapper<OrganisationEntity> mapper, IDatabase database) : base(mapper, database)
        {
        }
        protected override SqlCommand CreateGetCommand(int id)
        {
            var command = new SqlCommand(@"SELECT t.Id, t.Description FROM Organisation t Where t.Id = @Id");
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            return command;
        }
    }
    public class OrganisationEntityMapper : IEntityMapper<OrganisationEntity>
    {
        public OrganisationEntity MapAll(SqlDataReader reader)
        {
            return new OrganisationEntity();  // Populate using the reader...
        }
    }
