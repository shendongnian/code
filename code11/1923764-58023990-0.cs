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
Edit: Added code
