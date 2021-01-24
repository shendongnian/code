	/// <summary>
	/// Covers:
	/// - queue binding to custom object
	/// - queue trigger
	/// - table writing
	/// </summary>
	public static void QueueToICollectorAndQueue(
		[QueueTrigger(TestQueueNameEtag)] CustomObject e2equeue,
		[Table(TableName)] ICollector<ITableEntity> table,
		[Queue(TestQueueName)] out CustomObject output)
	{
		const string tableKeys = "testETag";
		DynamicTableEntity result = new DynamicTableEntity
		{
			PartitionKey = tableKeys,
			RowKey = tableKeys,
			Properties = new Dictionary<string, EntityProperty>()
			{
				{ "Text", new EntityProperty("before") },
				{ "Number", new EntityProperty("1") }
			}
		};
		table.Add(result);
		result.Properties["Text"] = new EntityProperty("after");
		result.ETag = "*";
		table.Add(result);
		output = e2equeue;
	}
