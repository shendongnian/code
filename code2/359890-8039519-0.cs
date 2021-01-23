    String jobDesc = @"flip burger
    &#149; fun
    &#149; fashionable
    You will love it
    &#149; 401k
    &#149; great times
    apply today
    tell your friends
    ";
    
    string [] lines = jobDesc.Split(new [] {"\n"}, StringSplitOptions.RemoveEmptyEntries);
    
    string bul = "&#149;";
    string result = string.Empty;
    bool inList = false;
    foreach (var line in lines)
    {
        if(line.Contains(bul))
        {
            if(!inList)
            {
                result += "<ul>\n";
                inList = true;
            }
            result += " <li>" + line.Replace(bul, string.Empty).Trim() + "</li>\n";
        }
        else
        {
            if(inList)
            {
                result += "</ul>\n";
                inList = false;
            }
            result += line;
        }
    }
