		List<string> players = new List<string> {
			@"Grady is 6'1"" ft",
			@"Robert is 5'10"" ft",
			@"Riley is 7 ft",
			@"Sam is 4'9"" ft",
			@"Greg is 6 ft",
			@"Raheem is 6'3"" ft",
			@"Connor is 5'11"" ft"
		};
		const string pattern = @"(.+) is (\d+)('\d+"")? ft";
		var regex = new Regex(pattern);
		foreach (var player in players)
		{
			var match = regex.Match(player);
			if (match.Success)
			{
				bool sixFeetOrTaller = false;
				var name = match.Groups[1].Value;
				var inchesStr = match.Groups[2].Value;
				int inches;
				if (int.TryParse(inchesStr, out inches))
				{
					if (inches >= 6)
					{
						sixFeetOrTaller = true;
					}
				}
				if (sixFeetOrTaller)
				{
					Console.WriteLine(name + " made it to the team!");
				}
				else
				{
					Console.WriteLine(name + " did not make it to the team");
				}
			}
			else
			{
				Console.WriteLine("Unable to parse line " + player);
			}
		}
