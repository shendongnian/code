	var newjson =
		new JObject(
		new JProperty("spec", 
					  new JObject(
						  new JProperty("name","SampleVM"),                  
						  new JProperty("cpu",new JObject
										{ 
											new JProperty("hot_remove_enabled",true),
											new JProperty("count",1),
											new JProperty("hot_add_enabled",true),
											new JProperty("cores_per_socket",1)
										}),
						  new JProperty("disks", new JArray(
							  new JObject
							  {
								  new JProperty("new_vmdk",new JObject{
									  new JProperty("capacity",1024)
								  })
							  }
						  )))));	
