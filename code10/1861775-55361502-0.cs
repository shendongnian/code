    using Microsoft.AnalysisServices;
    using Microsoft.AnalysisServices.Tabular;
    string connStr = @"Data Source=ServerName";
    string dataSource = "Data Source Name";
    string measureExpression = @"SUM('FactTable'[Amount])";
    using (Server serv = new Server())
    {
        serv.Connect(connStr);
    
        string dbName = serv.Databases.GetNewName("New Tabular Model Name");
    
        Database db = new Database()
        {
            Name = dbName,
            ID = dbName,
            CompatibilityLevel = 1200,
            StorageEngineUsed = StorageEngineUsed.TabularMetadata
        };
    
    
        db.Model = new Model()
        {
            Name = "Model",
            Description = "Model Description"
        };
    
        //define data source
        db.Model.DataSources.Add(new ProviderDataSource()
      {
      Name = dataSource,
      Description = "Data Source Description",
      //for SQL server
      ConnectionString = @"Provider=SQLNCLI11;Data Source=ServerName;Initial Catalog=DatabaseName;Integrated Security=SSPI",
      ImpersonationMode = Microsoft.AnalysisServices.Tabular.ImpersonationMode.ImpersonateAccount,
      Account = @"AccountName",
      Password = "Password",
      });
    
        //add tables
        //dimension table
        db.Model.Tables.Add(new Table()
        {
            Name = db.Model.Tables.GetNewName("DimTable"),
            Description = "Dimension Table Description ",
            Partitions = {
            new Partition() {
                Name = "Partition 1",
                Source = new QueryPartitionSource() {
                    DataSource = db.Model.DataSources[dataSource],
                    Query = @"SELECT ID, NAME FROM DimensionTable",
                }
            }
        },
            Columns =
        {
            new DataColumn() {
                Name = "ID",
                DataType = DataType.Int64,
                SourceColumn = "ID",
            },
            new DataColumn() {
                Name = "Name",
                DataType = DataType.String,
                SourceColumn = "NAME",
            },
        }
        });
    
        //fact table
        db.Model.Tables.Add(new Table()
        {
            Name = db.Model.Tables.GetNewName("FactTable"),
            Description = "FactTable Description",
            Partitions = {
            new Partition() {
                Name = "Partition 1",
                Source = new QueryPartitionSource() {
                    DataSource = db.Model.DataSources[dataSource],
                    Query = @"SELECT ID, AMOUNT FROM FactTable",
                }
            }
        },
            Columns =
        {
            new DataColumn() {
                Name = "ID",
                DataType = DataType.Int64,
                SourceColumn = "ID",
            },
            new DataColumn() {
                Name = "Amount",
                DataType = DataType.Int64,
                SourceColumn = "AMOUNT",
            },
        }
        });
    
        //create column objects for relationship
        Column fromColumn = db.Model.Tables["FactTable"].Columns["ID"];
        Column toColumn = db.Model.Tables["DimTable"].Columns["ID"];
    
        //create relationship to filter fact table
        SingleColumnRelationship relationship = new SingleColumnRelationship()
        {
            Name = "FactTable_ID_DimTable_ID",
            ToColumn = toColumn,
            FromColumn = fromColumn,
            ToCardinality = RelationshipEndCardinality.One,
            FromCardinality = RelationshipEndCardinality.Many
            
        };
        db.Model.Relationships.Add(relationship);
    
        //create measure
        Measure measure = new Measure()
        { Name = "Total" };
        db.Model.Tables["FactTable"].Measures.Add(measure);
        measure.Expression = measureExpression;
        serv.Databases.Add(db);
    
        //deploy database to SSAS Server
        db.Update(UpdateOptions.ExpandFull);
    
        //process new model so it's available to query
        db.Model.RequestRefresh(Microsoft.AnalysisServices.Tabular.RefreshType.Full);
        db.Update(UpdateOptions.ExpandFull);
    }
