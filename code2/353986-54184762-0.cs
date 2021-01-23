		public static List<dynamic> ListDictionaryToListDynamic(List<Dictionary<string,object>> dbRecords)
		{
			var eRecords = new List<dynamic>();
			foreach (var record in dbRecords)
			{
				var eRecord = new ExpandoObject() as IDictionary<string, object>;
				foreach (var kvp in record)
				{
					eRecord.Add(kvp);
				}
				eRecords.Add(eRecord);
			}
			return eRecords;
		}
