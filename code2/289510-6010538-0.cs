    var json = new JArray(
    				new JObject(
    					new JProperty("name", "student1"),
    					new JProperty("projects", 
    						new JArray(
    							new JObject(
    								new JProperty("name", "Project1"),
    								new JProperty("tasks", 
    									new JArray(
    										new JObject(
    											new JProperty("name", "task1"),
    											new JProperty("id", 2)
    											)
    										)
    									),
    								new JProperty("id", 6)
    							)
    						)
    					)
    				),
    				new JObject(
    					new JProperty("name", "student2"),
    					new JProperty("projects", 
    						new JArray(
    							new JObject(
    								new JProperty("name", "Project1"),
    								new JProperty("tasks", 
    									new JArray(
    										new JObject(
    											new JProperty("name", "task2"),
    											new JProperty("id", 1)
    											),
    										new JObject(
    											new JProperty("name", "task3"),
    											new JProperty("id", 3)
    											),
    										new JObject(
    											new JProperty("name", "task4"),
    											new JProperty("id", 4)
    											)
    										)
    									),
    								new JProperty("id", 2)
    							)
    						)
    					)
    				)
    			);
    var jsonString = json.ToString();
