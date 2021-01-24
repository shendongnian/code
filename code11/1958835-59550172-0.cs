    public static object ConvertStringToJson (string convertThisToJson)
    {
        if (string.IsNullOrEmpty(convertThisToJson))
            return JsonConvert.DeserializeObject<object>(JsonConvert.SerializeObject("{}"));
        string[] splitStr = convertThisToJson.Split(':');
        Dictionary<string, string> dict = new Dictionary<string, string>();
        string key, value;
        // First element will always be Key
        key = splitStr[0];
        // Everything in the middle will be Value/NextKey pair (not key/Value)
        for (int i = 1; i < splitStr.Count() - 1; i++)
        {
            // You suggested your value could have commas ... thus LastIndexOf
            int indexSplit = splitStr[i].LastIndexOf(",");
            value = splitStr[i].Substring(0, indexSplit);
            dict.Add(key, value.Trim());
            key = splitStr[i].Substring(indexSplit + 1);
        }
        // Last element in its entirety will be value.
        value = splitStr[splitStr.Length - 1];
        dict.Add(key, value.Trim());
        // You can choose to do either of these.
        //return JsonConvert.SerializeObject(dict); // Do change the return type if you decide to go with this.
        return JsonConvert.DeserializeObject<object>(JsonConvert.SerializeObject(dict));
    }
and use it like this 
    string str = "checkinDate: 2020-07-01,checkoutDate: 2020-07-05,room: Y,Y,Y";
    object jsonObj = ConvertStringToJson(str);
    Console.WriteLine(jsonObj.ToString()); // Print Json Object
    Console.WriteLine(JsonConvert.SerializeObject(jsonObj)); // Print String
**Output**
// Json Object.
{
  "checkinDate": "2020-07-01",
  "checkoutDate": "2020-07-05",
  "room": "Y,Y,Y"
}
// String
{"checkinDate":"2020-07-01","checkoutDate":"2020-07-05","room":"Y,Y,Y"}
