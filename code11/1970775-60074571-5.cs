    try
    {
        var result = new TextExtractor().Extract(yourPDF.pdf).Text;
        
        Console.WriteLine(result.Text.Length);
        
        foreach(var line in result)
        {
            if(line.contains("kullen"))
                /** Do Something **/
        }
    }
    catch(Exception e)
    {
        Console.WriteLine("Error occurred: " + e);
    }
