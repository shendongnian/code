    var s = "[['o_Module.Id'].Text]"; 
    //"[Object[Key='o_Module.Id'].Text]"; //ALSO MATCHES THIS
    var r = new System.Text.RegularExpressions.Regex(@"(\[?.*\[?')(.*)('.*)");
    var m = r.Match(s);
    if (m.Success)
    {
        //0 contains whole string
        Console.WriteLine(m.Groups[2].Value); //Prints o_Module.Id
    }
