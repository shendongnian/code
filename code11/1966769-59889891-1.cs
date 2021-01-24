using System;
using System.Collections.Generic;
using System.Linq;
(...)
var customers = new List<Customer>();
//Your logic to create customers here
var c1 = new Customer("Bob", 100, 10);
customers.Add(c1);
var c2 = new Customer("Bob", 200, 20);
customers.Add(c2);
var c3 = new Customer("Alice", 100, 10);
customers.Add(c3);
//Find all Bobs
var bobs = customers.Where(c => c.Name == "Bob");
foreach (var bob in bobs )
{
	Console.WriteLine($"Bob's initial deposit is {bob.InitialDeposit}");
}
----
Please note that names of classes are normally capitalised, e.g. `Customer`.
It's also common to keep fields private in classes and use properties for public access.
Here is an variant of the Customer class:
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
