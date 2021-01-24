    var listA = new List<string>();
    	listA.Add("test");
    	listA.Add("123");
    	listA.Add("5.7");
	
       var listB = new List<Type>();
        listB.Add(typeof(string));
        listB.Add(typeof(int));
        listB.Add(typeof(float));
       var index =-1;
	try{
	var newList = listA.Select((x, i)=>  Convert.ChangeType(x, listB[(index = i)])).ToList();
		
	}catch(Exception e){
		
     throw  new Exception("Failed to cast value "+listA[index]+" to "+listB[index]);
	
	}
