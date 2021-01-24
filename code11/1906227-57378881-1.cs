    [BsonDiscriminator("data")]
    public class DataClass
    {
        #region Private Fields
    
        private const string MongoCollectionName = "Data";
    
        #endregion
    
        #region Public Properties
    
        public string CollectionName => MongoCollectionName;
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("date_value")]
        public DateTime DateValue { get; set; }
        [BsonElement("group_id")]
        public int GroupId { get; set; }
        [BsonElement("data_type")]
        public string DataType { get; set; }
        [BsonElement("summary_count")]
        public long SummaryCount { get; set; }
        [BsonElement("flagged_count")]
        public long FlaggedCount { get; set;  }
        [BsonElement("error_count")]
        public long ErrorCount { get; set;  }
    
        #endregion
    
        #region Constructor
    
        public DataClass()
        {
    
        }
    
        public DataClass(int groupId, string dataType = null, long summaryCount = 0, long flaggedCount = 0, long errorCount = 0)
        {
            Id = ObjectId.GenerateNewId();
            DateValue = DateTime.UtcNow;
            GroupId = groupId;
            DocCount = summaryCount;
            DataType = dataType ?? "default_name";
            FlaggedCount = flaggedCount;
            ErrorCount = errorCount;
        }
    
        #endregion
    
        #region Public Methods
    
        public static IEnumerable<CreateIndexModel<AuditEntry>> GetIndexModel(IndexKeysDefinitionBuilder<AuditEntry> builder)
        {
            yield return new CreateIndexModel<AuditEntry>(
                builder.Combine(
                    builder.Descending(entry => entry.DateValue), 
                    builder.Ascending(entry => entry.GroupId), 
                    builder.Ascending(entry => entry.DataType)
                    )
                );
        }
    
        #endregion
    }
