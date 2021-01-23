    var firstName = "";
    var lastName = "";
    var split = testcase.Split(new char[] { ' ' }, 2);
    if (split.Length == 1)
    {
    	firstName = "";
    	lastName = split[0];
    }
    else
    {
    	firstName = split[0];
    	lastName = split[1];
    }
