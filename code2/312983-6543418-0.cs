    using Microsoft.VisualBasic.FileIO.TextFieldParser;
    TextFieldParser parser = new TextFieldParser("2,1016,7/31/2008 14:22,Geoff Dalgas,6/5/2011 22:21,http://stackoverflow.com,"Corvallis, OR",7679,351,81,b437f461b3fd27387c5d8ab47a293d35,34");
    parser.HasFieldsEnclosedInQuotes = true;
    parser.SetDelimiters(",");
    string[] fields;
    while (!parser.EndOfData)
    {
        fields = parser.ReadFields();
        foreach (string field in fields)
        {
            Console.WriteLine(field);
        }
    } 
    parser.Close();
