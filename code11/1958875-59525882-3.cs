  string newFormatted = JsonConvert.SerializeObject(JObject.Parse(json), Formatting.Indented).Replace(":", "=");
  Console.WriteLine(newFormatted);
**Output**
{
  "Prop1"= "Prop1Value",
  "Prop2"= 1,
  "Prop3"= "Prop3Value",
  "dtProp"= "2019-12-30T09=59=48"
}
**Printing Without Quotes on Keys**
If you are interested in printing the Keys without quotes, you can run the following method. This method breaks each line and removes quotes from Each Key.
    string str = JsonConvert.SerializeObject(JObject.Parse(json), Formatting.Indented);
    string newStr = string.Empty;
    str.Split(',').ToList().ForEach(line => newStr += string.Join("=", line.Split(':').Select((x, index) => index % 2 == 0 ? x.Replace(@"""", "") : x)));
**Output**
{
  Prop1= "Prop1Value"
  Prop2= 1
  Prop3= "Prop3Value"
  dtProp= "2019-12-30T09=59=48"
}
