	if (InExistingTxt && !File.Exists(path))
		return;
		
	StreamWriter SW;
		
	if (RemoveLast)
		SW = File.CreateText(path);
	else 
		SW = File.AppendText(path);
	
	using (SW)
	{
		for (int i = 0; i < Count; i++)
		{
			string st = "";
			for (int j = 0; j < Length; j++)
			{
				int o = Generator.Next(0, 11);
				st += Convert.ToString(o);
			}
			SW.WriteLine(st);
		}
	}
