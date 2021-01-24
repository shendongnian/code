foreach( string record in stringsFromDB) 
{
    var regexPattern = "I love .* Code";
    var match = Regex.Match(record, regexPattern);
    if(match.Success){
        Console.WriteLine("String matches");
    }else{
        Console.WriteLine("String not matches");
    }
    Console.WriteLine(record); //not sure with replace I love code, is it I love code or I love <anything> code?
}
