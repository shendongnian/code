c#
public class CharacterStrings
{
    public List<CharacterStringObject> CharacterString { get; set; }
}
c#
public class CharacterStringObject
{
    public string CharacterString { get; set; }
    public long CharacterStringWriteable { get; set; }
    public DateTime ChangedAt { get; set; }
}
After that, after you read your JSON like that:
c#
CharacterString CSV = JsonConvert.DeserializeObject<CharacterString>(JSON);
[![enter image description here][1]][1]
You end up with `List<CharacterStringObject>` with one element in it. So you take the first one like that and print it:
c#
Console.WriteLine("Sensor data: " + CSV.CharacterString.First().CharacterString);
Cheers,  
Edit: Tested it locally with your given JSON, works fine  
  [1]: https://i.stack.imgur.com/SzFO0.png
