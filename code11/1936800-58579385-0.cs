    using Microsoft.VisualBasic.FileIO;
    using System.IO;
    
    string text; // This contains the text I posted in the question.
    List<string[]> multilineString = new List<string[]>();
    byte[] byteArray = Encoding.UTF8.GetBytes(text);                 // convert string to stream
    MemoryStream stream = new MemoryStream(byteArray);
    using (var myString = new TextFieldParser(stream))
    {
    	myString.TextFieldType = FieldType.Delimited;
    	myString.SetDelimiters("\t");
    	myString.HasFieldsEnclosedInQuotes = true;
    	while (!myString.EndOfData)
    	{
    		string[] fieldArray;
    		try
    		{
    			fieldArray = myString.ReadFields();
    			multilineString.Add(fieldArray);
    		}
    		catch (Microsoft.VisualBasic.FileIO.MalformedLineException ex)
    		{
    			continue;
    		}
    	}
    }
