    var stringUrl = "http://localhost/?name=Jonathan&lastName=Morales";
    var decoder = new WwwFormUrlDecoder(stringUrl);
    //Using GetFirstByName method
    string nameValue = decoder.GetFirstByName("name");
    //nameValue has "Jonathan"
    
    //Using Lambda Expressions
    var parameter = decoder.FirstOrDefault(p => p.Name.Contains("last")); //IWwwFormUrlDecoderEntry variable type
    string parameterName = parameter.Name; //lastName
    string parameterValue = parameter.Value; //Morales
