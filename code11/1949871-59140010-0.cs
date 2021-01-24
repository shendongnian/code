       string input = "abc10gf-5h1";
		var number = new char[10];
		int numberlength = 0;
		int pos = 0;
		
		int sum = 0;
		while (pos < input.Length)
		{
			char c = input[pos++];
			if (char.IsDigit(c) || c=='-')
			{
				number[numberlength++]=c;
			}
			else if (numberlength > 0)
			{
				sum += int.Parse(new String(number, 0, numberlength));
				numberlength = 0;
			}
		}
		if (numberlength > 0)
				sum += int.Parse(new String(number, 0, numberlength));
		
		Console.WriteLine(sum);
