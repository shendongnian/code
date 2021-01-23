    using Microsoft.VisualBasic.FileIO; //Microsoft.VisualBasic.dll
    ...
    using(var csvReader = new TextFieldParser(reader)){
        csvReader.SetDelimiters(new string[] {","});
        csvReader.HasFieldsEnclosedInQuotes = true;
        fields = csvReader.ReadFields();
    }
