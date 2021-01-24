static void LoadData(string filename, List<string> questions, List<string> answers)
{
	string readText = ""; //for writing error at catch clause.
	try
	{
		using (StreamReader reader = new StreamReader(filename))
		{
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				readText = line;  //copy text line which is current.
				string[] lineArray = line.Split(',');
				string annswer = lineArray[1];
				string question = lineArray[0];
				questions.Add(question);
				answers.Add(annswer);
			}
		}
	}
	catch (Exception e)
	{
        //print error with problem text.
		Console.WriteLine("File could not be read from : {0}", readText);  
		Console.WriteLine(e.Message);
	}
}
Also, this is another,   
Move to : Menu -> DEBUG -> Windows -> Exception settings.
And then check "Common Language Runtime Exception".
This will allow stop where occur problem. It doesn't matter that is in try~catch clause or not.  
This is one of best way to find problem in loop statement.
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/q8N9m.png
