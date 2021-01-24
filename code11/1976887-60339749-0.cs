			//adding first string to list
			listOfObjects.Add("First string");
			//adding integers to list
			for (int j = 0; j < 5; j++)
			{
				listOfObjects.Add(j);
			}
			listOfObjects.Add("Second string");
			for (int k = 5; k < 10; k++)
			{
				listOfObjects.Add(k);
			}
			foreach (var obj in listOfObjects)
			{
				Console.WriteLine(obj);
			}
			var sum = 0;
			for (var l = 0; l < 4; l++)
			{
				var a = listOfObjects[l].GetType();
				if (a == typeof(int))
				{
					sum += (int)listOfObjects[l];
					Console.WriteLine("I've get an integer type.");
				}
				Console.WriteLine("I've get only string type.");
			}
			Console.WriteLine(sum);
			Console.Read();
