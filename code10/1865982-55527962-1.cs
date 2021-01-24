    Dictionary<string, List<ClassSched>> dictClassSched = new Dictionary<string, List<ClassSched>>();
    
    /*
        * Here you open up your Json file and read it,
        * then you loop over the rows
        * and grab the class Code and assign it to classCode variable
        * and assign the row of the json into the jsonRow variable.
        * 
        */
    
    var c = JsonConvert.DeserializeObject<ClassSched>(jsonrow.ToString());
    if ( dictClassSched.TryGetValue(classCode, out List<ClassSched> scheds))
    {
        scheds.Add(c);
        dictClassSched[classCode] = scheds;
    }
    else
    {
        dictClassSched.Add(classCode, new List<ClassSched>() { c });
    }
 
