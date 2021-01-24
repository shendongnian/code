List<string> Source = {}; //source list
List<string> Females = new List<string>(), Males = new List<string>(); 
foreach (string value in Source)
{
    if (value.ToUpper().Contains(",F,")) //Female
    {
        Females.Add(value);        
    }
    else
    {
        Males.Add(value);
    }
}//result: both lists are with values
That's it.
if you's like to make it shorter:
string filename = "textfilename.text" //file name to open
List<string> Females = new List<string>(), Males = new List<string>(); 
foreach (string line in File.ReadLines()) //openning file
{
    if (line.ToUpper().Contains(",F,")) //Female
    {
        Females.Add(line);        
    }
    else
    {
        Males.Add(line);
    }
}//same result
to get other properties, maybe you'd like to use the method `String.Split(',')` which returnd array (in your case, string[3])
