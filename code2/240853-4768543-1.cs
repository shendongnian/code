		string input = "look at the sleep box";
		bool caseA = input.Contains("sleep");
		bool caseB = input.Contains("look") && input.Contains("box");
		
		int scenarioId;
		if (caseA && caseB)
			scenarioId = 1;
		else if (caseA)
			scenarioId = 2;
		else if (caseB)
			scenarioId = 3;
		// more logic?
		else
			scenarioId = 0;
			
		switch (scenarioId)
		{
			case 1:
				Console.WriteLine("Do scenario 1");
				break;
			case 2:
				Console.WriteLine("Do scenario 2");
				break;
			case 3:
				Console.WriteLine("Do scenario 3");
				break;
			// more cases
			default:
				Console.WriteLine("???");
				break;
		}
