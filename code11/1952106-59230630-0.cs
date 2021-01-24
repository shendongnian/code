 // calling getValue() method 
stringSomeBool = getValue(user.SomeBool); 
HttpContext.Session.SetString("SomeBool", stringSomeBool.ToLower()); 
    // defining getValue() method 
    public static void getValue(bool variable) 
    { 
  
        // getting the value of string property 
        string value = variable.ToString(); 
  
        // print the string property 
        Console.WriteLine("{0}", value); 
    } 
