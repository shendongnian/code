	try	
	{
	   foreach (string d in Directory.GetDirectories("C:\")) 
	   {
		foreach (string f in Directory.GetFiles(d, *.*)) 
		{
		   if(DateTime.Compare(f.GetCreationTime, datetime))
           {
             //files found            
           }
		}
		DirSearch(d);
	   }
	}
	catch (System.Exception excpt) 
	{
		Console.WriteLine(excpt.Message);
	}
}
