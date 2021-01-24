return new List<BsonDocument>
{
	new BsonDocument
	{
		{
			"$match", new BsonDocument
			{
				{
					"$expr", new BsonDocument
					{
						{
							"$and", new BsonArray
							{
								new BsonDocument
								{
									{
										"$gt", new BsonArray 
										{
											"$property1", "$property2"
										}
									}
								},
								new BsonDocument
								{
									{
										"$gt", new BsonArray 
										{
											"$property1", "$property3"
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
};
