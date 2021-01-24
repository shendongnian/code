    	string input = "D @#.O()/?#G";
		
		StringBuilder builder = new StringBuilder();
		
		for (int i = input.Length-1; i >= 0; i--)
		{
			if (Char.IsLetter(input[i]))
			{
				builder.Append(input[i]);
			}
		}
		
		string result = builder.ToString();
