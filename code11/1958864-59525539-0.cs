    var line = $"13351.750815 26646.150876 6208.767863 26646.150876 1219.200000 914.400000 0.000000 1 \"Beam 1\" 0 1 1 1 0 1 1e8f59dd-142d-4a4d-81ff-f60f93f674b3";
    line = line.Trim(); //remove leading and trailing white space
    var tempArray1 = line.Split('"'); //split the line to a string array on "
    								  //so the string array we get, is everything before, between, and after "
    
    //.Select((element, index)
    //Basically doing a for-loop on the array we got
    List<string[]> tempListForElements = new List<string[]>(); //initialize a temporary list of string arrays we're going to be using
    for (var index = 0; index < tempArray1.Length; index++)
    {
        var element = tempArray1[index];
    
        //now we're getting to the ternary, which is basically like an inline if-else statement
        //index % 2 == 0 ? <if true> : <if false>
        //if remainder of division by 2 is 0, so basically a way of doing two 
        //different things for every other iterator of the loop
        if (index % 2 == 0)
        {
            //if on the first or last iteraton on the loop (before and after " in the line)
            tempListForElements.Add(element.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries));  //we create yet another string array splitting on each whitespace and add it to our temporary list
        }
        else
        {
            //if on the second iteraton on the loop (between ")
            tempListForElements.Add(new string[] { element }); //we're creating yet another string array, this time there's just one element in the array though, and then add it to our temporary list
        }
    }
    
    //.SelectMany(element => element).ToList()
    //we're basically turning out list of 3 string array into one string array
    //can't be asked to type it out in non linq since just realized there are some good answers here already,
    //but imagine initializing a string array with the correct size and then a foreach loop adding each string to it in order.
