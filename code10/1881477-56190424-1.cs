    public static async Task Run(
        [TimerTrigger("0 * * * * *")] TimerInfo myTimer,
        ILogger log,
        [CosmosDB(
            databaseName: "db_id",
            collectionName: "col_id",
            ConnectionStringSetting = "CosmosDBConnectionString",
            SqlQuery = "SELECT * FROM col_id")
        ] IEnumerable<Doc> documents
    )
