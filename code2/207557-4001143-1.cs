    public class Status
    {
      public string ViewState {get; set;}
      public string EventValidation {get; set;}
    }
    using System;
    using HtmlAgilityPack;
    [...]
    public Status GetStatus(string localFileName)
    {
        var dtsDoc = new HtmlDocument();
        dtsDoc.Load(localFileName);
        //Pull the values
        var viewStateNode = dtsDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/input[4]/@value[1]");
        var eventValidationNode = dtsDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[2]/input[1]/@value[1]");
        string viewState = viewStateNode.Attributes[3].Value;
        string eventValidation = eventValidationNode.Attributes[3].Value;
        //Display the values
        //Console.WriteLine(viewState);
        //Console.WriteLine(eventValidation);
        //Console.ReadKey();
        return new Status
        {
          ViewState = viewState,
          EventValidation = eventValidation
        }
    }
