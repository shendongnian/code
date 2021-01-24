static void Main(string[] args)
{
int temp = 0, total = 0, sum = 0;
			double avg;
			string  tempString=string.Empty;
			Console.WriteLine("Enter daily high temperatures, to stop program enter 999.");
			tempString = Console.ReadLine();
			temp = Convert.ToInt32(tempString);
			while (temp != 999)
			{
				if (temp >= 20 && temp <= 130)
				{
					Console.WriteLine("Enter daily high temperatures, to stop program enter 999");
					tempString = Console.ReadLine();
					temp = Convert.ToInt32(tempString);
					sum += temp;
					total++;
				}
				else
				{
					Console.WriteLine("Valid temperatures range from -20 to 130. Please reenter temperature.");
					Console.ReadLine();
				}
			}
			
			
			avg = sum / total;
			Console.WriteLine("The number of temperatures entered: {0} {2}The average temperature is: {1}.", total, avg,"\n");
}
