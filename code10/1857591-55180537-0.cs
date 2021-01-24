    string input = "jasabcasjlabcdjjakabcdehahakabcdef";
    List<string> result = new List<string>();
    string temp = string.Empty;
         
    foreach(char c in input)
    {
        if(c == 'a' && temp == string.Empty)
        {
            temp = string.Empty;
            temp += c;                
        }
        else if(c - 1  == temp.LastOrDefault())
        {
            temp += c;                  
        }
        else if (!string.IsNullOrEmpty(temp))
        {
            if (temp.StartsWith("abc"))
            {
                result.Add(temp);
            }
            temp = string.Empty;
        }
    }
    if (temp.StartsWith("abc"))
    {
        result.Add(temp);
    }
