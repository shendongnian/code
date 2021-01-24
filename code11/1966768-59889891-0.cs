public class Customer
{
	public Customer(string name, int initialDeposit, int monthlyDeposit)
	{
		Name = name;
		InitialDeposit = initialDeposit;
		MonthlyDeposit = monthlyDeposit;
	}
	public string Name { get; }
	public int InitialDeposit { get; }
	public int MonthlyDeposit { get; }
}
