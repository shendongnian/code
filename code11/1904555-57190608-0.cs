	using(var parser = new TextFieldParsser(file))
    {
    Int32 skipHeader = 0;
    parser.SetDelimiters("|");
	while (!parser.EndOfData)
	{
		//Processing row
		string[] fields = parser.ReadFields();
		Int32 x = 0;
		if (skipHeader > 0)
		{
			foreach (var field in fields)
			{
				if (x == 0)
				{
					//SAVE STUFF TO VARIABLE
				}
				else if (x==4)
				{
					//SAVE MORE STUFF
				}
				else if (x == 20)
				{
					//SAVE LAST STUFF
					
					break;//THIS IS THE LAST COLUMN OF DATA NEEDED SO YOU BREAK
				}
				
				x++;
			}
			//DO SOMETHING WITH ALL THE SAVED STUFF AND CLEAR IT OUT
		}
		else
		{
			skipHeader++;
		}
	}}
