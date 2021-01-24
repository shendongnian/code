	using System;
	namespace Register
	{
		class Program
		{
			static void Main(string[] args)
			{
				int donNum;
				const double coverCharge = 0.25;
				string customerLastName;
				const double tax = 1.13;
				double donCost;
				double total;
				do
				{
					Console.WriteLine("Hi, can I get your name for your order? ");
					customerLastName = Console.ReadLine();
				} while (NameInvalid(customerLastName));
				do
				{
					Console.WriteLine("How many donut's would you like?");
					donNum = Convert.ToInt32(Console.ReadLine());
				} while (DonNumInvalid(donNum));
				if (donNum >= 15)
				{
					donCost = 0.75;
					total = (donNum * donCost) + coverCharge;
				}
				else if (donNum > 12 && donNum < 15)
				{
					donCost = 0.90;
					total = (donNum * donCost) + coverCharge;
				}
				else if (donNum > 0 && donNum <= 7)
				{
					donCost = 1.00;
					total = ((donNum * donCost) * tax) + coverCharge;
				}
				else
				{
					Console.WriteLine("Invalid input! Please try again");   
				}
				Console.WriteLine("Your total for {0} donuts is {1}", donNum);
				Console.WriteLine("Your total cost of {0} donuts is {1}", donNum);
				Console.ReadKey();
			}
			
			private bool NameInvalid(string name)
			{
				if (/*Check if name is valid*)
					return true
				
				return false;
			}
			
			private bool DonNumInvalid(int number)
			{
				if (/*Check if doughnut number  valid*)
					return true
				
				return false;
			}
		}
	}
