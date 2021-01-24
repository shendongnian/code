    String __content = "[ {\"name\": \"person1\" , \"age\": 33} , {\"name\": \"person2\" , \"age\" : 23} ]";
			dynamic data = JsonConvert.DeserializeObject(__content);
			// make sure you have an array of object
			if (data is Newtonsoft.Json.Linq.JArray)
			{
				int i = 0;
				foreach (dynamic item in data)
				{
					// get the property of the object 
					JObject currentitem = ((JObject)item);
					// access to value of each property
					foreach (JProperty p in currentitem.Properties())
					{
						Console.WriteLine("[" + i + "] : " + p.Name + ":" + p.Value.ToString());
					}
					i++;
				}
			}
