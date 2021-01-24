class SalesContainer
{
	private string _sales;
	public string getSales()
	{
		return _sales;
	}
	public string updateSales (string sales)
	{
		_sales = sales;
		sendData(sales);
	}
	private sendData(string json)
	{
		// your sending logic here
	}
}
Alternatively, you can look a bit into [operator overload](https://www.tutorialspoint.com/csharp/csharp_operator_overloading.htm) to allow you to makes less changes on your existing codebase.
