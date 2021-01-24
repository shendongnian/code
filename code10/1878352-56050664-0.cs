            const string sourceJson = "{  \"71\": {    \"longitude\": -179.5,    \"latitude\": -19.5  },  \"72\": {    \"longitude\": -179.5,    \"latitude\": -18.5  },  \"157\": {    \"longitude\": -179.5,    \"latitude\": 66.5  },  \"158\": {    \"longitude\": -179.5,    \"latitude\": 67.5  }}";
    
            private class OldEntry {
                public double longitude { get; set; }
                public double latitude { get; set; }
            }
    
            private class NewEntry {
                public int nodeId { get; set; }
                public double longitude { get; set; }
                public double latitude { get; set; }
            }
    
            static void Main(string[] args) {
                var oldData = JsonConvert.DeserializeObject<Dictionary<string, OldEntry>>(sourceJson);
                var newData = new List<NewEntry>(oldData.Count);
                foreach (var kvp in oldData) {
                    newData.Add(new NewEntry() {
                        nodeId = int.Parse(kvp.Key),
                        longitude = kvp.Value.longitude,
                        latitude = kvp.Value.latitude
                    });
                }
                Console.WriteLine(JsonConvert.SerializeObject(newData, Formatting.Indented));
            }
