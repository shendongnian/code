cs
public class Health
{
	public static implicit operator short(Health health)
	{ 
		return health.Current;
	}
	
	public short Current;
	public short Maximum;
}
The use it like this:
cs
Health h = new Health { Current = 20, Maximum = 100};
short current = h;
Console.WriteLine(current); // 20
