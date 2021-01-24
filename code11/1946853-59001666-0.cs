[
  {
    "id": 1,
    "name": "name 1",
    "address": {
      "Line1": "line 1",
      "Line2": "line 2"
    },
    "discount": 10.1100000000000000000000000
  },
  {
    "id": 2,
    "name": "name 2",
    "address": {
      "Line1": "line 1",
      "Line2": "line 2"
    },
    "discount": 123.1212121121212121
  },
  {
    "id": 3,
    "name": "name 3",
    "address": {
      "Line1": "line 1",
      "Line2": "line 2"
    },
    "discount": 123.1212121121212121
  }
]
And, in `CHECKS`, you need to filter out all objects whose `id` is not present in some list.  To do this, define the following model:
	public class UserObject
	{
		[JsonPropertyName("id")]
		public long Id { get; set; }
		
		[System.Text.Json.Serialization.JsonExtensionDataAttribute]
		public IDictionary<string, object> ExtensionData { get; set; } = new Dictionary<string, object>();
	}
And deserialize and filter as follows:
	var users = JsonSerializer.Deserialize<List<UserObject>>(rawJsonDownload);
	users.RemoveAll(u => existingUsers.Any(u2 => u.Id == u2.Id));
Notice that this approach ensures that properties relevant to filtering can be deserialized appropriately without needing to make any assumptions about the remainder of the JSON.  While this isn't as quite easy as using LINQ to JSON, the total code complexity is bounded by the complexity of the filtering checks, not the complexity of the JSON.
Demo fiddle [here](https://dotnetfiddle.net/eDvr7K).
