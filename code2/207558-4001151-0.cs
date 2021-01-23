    public String[] get_status(string local_fname) 
    { 
        var dts_doc = new HtmlAgilityPack.HtmlDocument(); 
        dts_doc.Load(local_fname); 
 
        //Pull the values 
        var ViewState = dts_doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/input[4]/@value[1]"); 
        var EventValidation = dts_doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[2]/input[1]/@value[1]"); 
 
        string ViewState2 = ViewState.Attributes[3].Value; 
        string EventValidation2 = EventValidation.Attributes[3].Value; 
        
        String[] retValues = new String[2];
        retValues[0] = ViewState2;
        retValues[1] = EventValidation2;
        return retValues;
 
        //Display the values 
 
        //System.Console.WriteLine(ViewState.Attributes[3].Value); 
        //System.Console.WriteLine(EventValidation.Attributes[3].Value); 
        //System.Console.ReadKey(); 
        return ViewState2; 
    } 
