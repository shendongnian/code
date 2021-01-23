    StreamReader reader = new StreamReader(filePath);
    string line;
    while(null != (line=reader.Read())
    {
        string[] splitLine = strLines.Split('='); 
        //Code to find specific items based on splitLine[0] - Example
        //TODO: Need a check for splitLine length
        case(splitLine[0].ToLower().Trim())
        {
            case "age": { age = int.Parse(splitLine[1]);
        }
    }
    
    reader.Dispose();
