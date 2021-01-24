public class ProblemClass
{
	static Random r = new Random();
	const string options = "ABC";
	public ProblemClass(int id)
	{
		Id = id;
		ProblemField = options[r.Next(options.Length)].ToString();
	}
	public int Id { get; }
	public string ProblemField { get; }
}
