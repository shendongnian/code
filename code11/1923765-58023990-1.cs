`
[Serializable]
public struct GiftValue
{
	public int Value;
	public int Weight;
}
[Serializable]
public class GiftConfig
{
	public List<GiftValue> Gifts;
}
public void LoadConfig(string filePath) {
	string fileContent = File.ReadAllText(filePath);
	var giftConfig = JsonUtility.FromJson<GiftConfig>(fileContent);
}
`
JSON would look like this:
`
{ 
    "Gifts":[ 
        { 
            "Value":1,
            "Weight":25
        },
        { 
            "Value":2,
            "Weight":25
        }
    ]
}
`
Edit: Added code and json
