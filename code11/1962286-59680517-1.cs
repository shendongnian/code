    using (FileStream fs = File.Create(filepath1)) 
	{
	}
	using (FileStream fs = File.Create(filepath2)) 
	{
	}
	using (StreamWriter wrt = new StreamWriter(filepath1, true))
	{
		Container1.ForEach(r => wrt.WriteLine(r));
	}
	using (StreamWriter wrt = new StreamWriter(filepath2, true))
	{
		Container2.ForEach(r => wrt.WriteLine(r));
	}        
