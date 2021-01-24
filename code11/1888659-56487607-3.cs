    using SimpleJSON;
    ...
    var jsonObject = JSON.Parse(the_JSON_string);
    string versionString = jsonObject["version"].Value;         // versionString will be a string containing "1.0"
    float versionNumber = jsonObject["version"].AsFloat;        // versionNumber will be a float containing 1.0
    string val = jsonObject["data"]["sampleArray"][0];          // val contains "string value"
    string name = jsonObject["data"]["sampleArray"][2]["name"]; // name will be a string containing "sub object"
    ...
    
