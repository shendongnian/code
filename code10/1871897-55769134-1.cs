    using Microsoft.VisualBasic.FileIO;
           protected void CSVImport(string importFilePath)
            {
                string csvData = System.IO.File.ReadAllText(importFilePath, System.Text.Encoding.GetEncoding("WINDOWS-1250"));
                foreach (string row in csvData.Split('\n'))
                {
    
    
                    var parser = new TextFieldParser(new StringReader(row));
                    parser.HasFieldsEnclosedInQuotes = true;
                    parser.SetDelimiters(",");
                    string[] fields;
                    fields = parser.ReadFields();
                   //do what you need with data in array
                }
         
            }
