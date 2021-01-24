    using System.Text;
    using System.Text.RegularExpressions;
    ...
    var examples = File.ReadAllLines(@"keywords.txt");
    //If you want to ignore case then, pass third parameter to IsMatch() "RegexOptions.IgnoreCase"
    if(examples.Any(x => Regex.IsMatch(json, $@"\b{x}\b"))   
    {
      // here "\b" stands for boundary
      //Your business logic
    }
    else
    {
      //Your business logic
    }
 
