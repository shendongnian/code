cs
[Serializable]
public class OutputPerDay
{
    public List<string>[] _pricesPerDay = new List<string>[3];
	
	public OutputPerDay()
	{
		for(int index = 0; index < 3; index++)
		{
			_pricesPerDay[0] = new List<string>();
		}
	}
	
    public List<string> Day1 => _pricesPerDay[0];
    public List<string> Day2 => _pricesPerDay[1];
    public List<string> Day3 => _pricesPerDay[2];
}
