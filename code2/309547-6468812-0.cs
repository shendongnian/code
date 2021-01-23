	Dictionary<string, Person> newPeople = ...
	foreach(row in fileRows)
	{
		Person person;
		
		//if the person is already tracked by the dictionary, work with it, if not use the repository
		if(!newPeople.TryGetValue(row.SSN, out person))
		{
			person = personRepository.GetBySSN(row.SSN);
		}
		
		if(person == null)
		{
			//insert logic
			
			//keep track that this person is already in line for inserting
			newPeople.Add(row.SSN, person);
		}
		else
		{
			//update logic
		}
	}
	personRepository.SaveChanges();
