	var msg = JObject.Parse(myEventHubMessage);
	
	msg.Property("data_in")?.Rename("data"); // Normalize the name "data_in" to be "data".
	msg["data"]?["ts"]?.MoveTo(msg);         // Normalize the position of the "ts" property, it should belong to the root object
	msg["data"]?["timestamp"]?.MoveTo(msg);  // Normalize the position of the "timestamp" property, it should belong to the root object
	msg.Property("timestamp")?.Rename("ts"); // And normalize the name of the "timestamp" property, it should be "ts".
			
				
