	for(int i = 0; i < objects.Count; i++)
	{
		if(objects[i].name == "John Smith")
		{
			 objects.Remove(objects[i--]);
		}
	}
