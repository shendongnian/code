    using Microsoft.VisualBasic.FileIO;
    using (TextFieldParser reader = new TextFieldParser(csvpath))
		   {
             reader.Delimiters = new string[] { "," };
             reader.HasFieldsEnclosedInQuotes = true;
             string[] col =  reader.ReadFields();
           }
             
