			string test= "1,23"; //Change to your locale decimal separator
			decimal num1; decimal num2;
			if(decimal.TryParse(test, out num1) && decimal.TryParse(test, out num2))
			{
				//we FORCE one of the numbers to be rounded to two decimal places
				num1 = Math.Round(num1, 2); 
				if(num1 == num2) //and compare them
				{
					Console.WriteLine("Passed! {0} - {1}", num1, num2);
				}
				else Console.WriteLine("Failed! {0} - {1}", num1, num2);
			}
        	Console.ReadLine();
