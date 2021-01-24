json
{
    "words": [
        {
            "catNr": "1",
            "category": "Kodu- ja taluloomad",
            "wordNr": "1",
            "est": "Koer",
            "eng": "Dog",
            "fin": "Koira",
            "esp": "Perro",
            "ger": "der Hund",
            "swe": "Hund"
        }
    ]
}
and generating, it quickly shows that apart from `Word` class there should be some `RootObject` class which contains `List` of `Word`s:
csharp
public class Word
{
    public string catNr { get; set; }
    public string category { get; set; }
    public string wordNr { get; set; }
    public string est { get; set; }
    public string eng { get; set; }
    public string fin { get; set; }
    public string esp { get; set; }
    public string ger { get; set; }
    public string swe { get; set; }
}
public class RootObject
{
    public List<Word> words { get; set; }
}
<br>(You can also rename `RootObject` to ex. `WordList` or whatever you like)
That means that in order to parse this JSON correctly, you should pass `RootObject` as type to `JsonUtility.FromObject<T>` (or `JsonConvert.DeserializeObject<T>` if you move to Json.NET):
csharp
RootObject myData = JsonUtility.FromJson<RootObject>(myLoadedItem);
Word singleWord = myData.words[0];
  [1]: https://assetstore.unity.com/packages/tools/input-management/json-net-for-unity-11347
  [2]: https://www.newtonsoft.com/json
  [3]: http://json2csharp.com/
