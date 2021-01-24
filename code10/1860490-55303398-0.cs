using System;
using System.Xml.Linq; //For the XDocument class
using Newtonsoft.Json; //For JsonConvert class
using System.IO; //For File class
class JsonToXMLProgram
{
    static void Main(string[] args)
    {
        string myJSONString = @File.ReadAllText(@"H:\MyJsonFile.json"); //Replace with your json files' locations.
        //This converts the JSON string to xml
        XDocument myXMLDocument = JsonToXML(myJSONString);
        //you could then check your xml by outputting it to the console...
        Console.WriteLine(myXMLDocument.ToString());
        //..or by saving the file to disk
        string myXMLFilePath = @"H:\MyXmlDocument.xml"; //Replace with the path to your generated xml files.
        myXMLDocument.Save(myXMLFilePath);
    }
    public static XDocument JsonToXML(string jsonString)
    {
        XDocument xmlDoc;
        try
        {
            xmlDoc = JsonConvert.DeserializeXNode(jsonString, "Root", true);
            return xmlDoc;
        }
        catch (JsonException e)
        {
            Console.WriteLine("There appears to be an error in the json file. Please validate the json to ensure that it is free from errors.");
            Console.WriteLine("Details: " + e.Message);
            return new XDocument();
        }
    }
}
