    List<double> myList = new List<double>(){ 1.0, 2.0, 3.0};
    
    //to byte[]
    var byteResult = GetBytesBlock(myList.ToArray());
    	
    //back to List<double>
    var doubleResult = GetDoublesBlock(byteResult).ToList();
	
    
