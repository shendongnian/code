	myObject = new myObject() { Id = 1 };
	
	List<myObject> listOfObjects = new List<myObject>();
	listOfObjects.Add(new myObject() { Id = 1 });
	
	var result = listOfObjects.Contains(myObject); // returns false, because the item in the list is a different object than myObject
	
	result = listOfObjects.Any(obj => obj.Id == myObject.Id); // returns true
