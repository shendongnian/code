    private Table<Genesis.Domain.Entities.Stream> streamTable;
    public SqlGenesisRepository(string connectionString)
    {
        streamTable = (new DataContext(connectionString)).GetTable<Genesis.Domain.Entities.Stream>();
    }
