public static void Main(string[] args)
{
	var validators = new[] { new Validator(666), new Validator(667) };
	var forValidations = new [] { new ForValidation("v1"), new ForValidation("v2") };
	Console.WriteLine("Before Verify");
	foreach (var fv in forValidations)
		Console.WriteLine($"Object: {fv.CheckProperty} - count of places: {fv.ExistsPlaces.Count()}");
	foreach (Validator validator in validators)
		validator.Verify(forValidations);
	Console.WriteLine("After Verify");
	foreach (var fv in forValidations)
		Console.WriteLine($"Object: {fv.CheckProperty} - count of places: {fv.ExistsPlaces.Count()}");
}
Result
Before Verify
Object: v1 - count of places: 0
Object: v2 - count of places: 0
After Verify
Object: v1 - count of places: 2
Object: v2 - count of places: 2
Classes:
public class ForValidation
{
	private readonly object @lock = new object();
	private readonly List<int> ExistenceChecks = new List<int>();
	public IEnumerable<int> ExistsPlaces => ExistenceChecks;
	public string CheckProperty { get; }
	public ForValidation(string checkProperty)
	{
		CheckProperty = checkProperty;
	}
	public void ConfirmExistence(int place)
	{
		lock (@lock)
		{
			ExistenceChecks.Add(place);
		}
	}
}
public class Validator
{
	public Validator(int validatorNumber)
	{
		ValidatorNumber = validatorNumber;
	}
	public int ValidatorNumber { get; }
	public void Verify(IEnumerable<ForValidation> forValidations)
	{
		ForValidation[] copy = forValidations.ToArray();
		IEnumerable<string> checkProperties = from member in copy
											  select member.CheckProperty;
		foreach (ForValidation forValidation in copy)
		{
			//if (existingMembers.FirstOrDefault(m => m.CheckProperty == forValidation.CheckProperty) != null)
			{
				forValidation.ConfirmExistence(ValidatorNumber);
			}
		}
		int x = copy.Length;
		//each forValidation.ExistsPlaces has items until this code block
	}
}
