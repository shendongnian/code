    string datestring = "20190519_562";
     //check first 8 characters are digit
    var rsult = datestring.Take(8).All(char.IsDigit);
     if(rsult == true)
     {
    // get last three characters of string 
    string dtst= datestring.Substring(datestring.Length - 4);
    if(dtst[0]== '_') // check first character is "_"
    {
     int length = dtst.Substring(1).Length; // get length of character after "_"
     if(length==3)
    {
    enter code here
     }
    
    }
     }
