[
    {
		"Id":"IdArticulo",
		"Fields":{"Origin":"IdArticulo","DestinationTable":"Articulos","DestinationField":"IdArticulo","DataType":"nvarchar"}
	},
	
	{
		"Id":"Nombre",
		"Fields":{"Origin":"Espanol","DestinationTable":"Articulos","DestinationField":"Descrip","DataType":"nvarchar"}
	}
]
And changed my C# code a bit and the end result is this:
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace modules.dataProcessing.ConfManager
{
    public class Fields
    {
        public string Origin { get; set; }
        public string DestinationTable { get; set; }
        public string DestinationField { get; set; }
        public string DataType { get; set; }
        public override string ToString()
        {
            string finalString = "Origin: " + this.Origin + "\n" + "DestinationTable: " + this.DestinationTable + "\n";
            finalString += "DestinationField: " + this.DestinationField + "\n" + "DataType: " + this.DataType;
            return finalString;
        }
    }
    public class FieldConfs
    {
        public string Id
        {
            get; set;
        }
        public Fields Fields
        {
            get; set;
        }       
    }
    public static class JsonTools
    {
        public static List<FieldConfs> loadConf(string json)
        {
            List<FieldConfs> fieldConfs = new List<FieldConfs>();
            fieldConfs = JsonConvert.DeserializeObject<List<FieldConfs>>(json);
            return fieldConfs;
        }
        public static void saveConf(List<FieldConfs> confs, string fileToSave)
        {
            using (StreamWriter file = File.CreateText(fileToSave))
            {
                JsonSerializer serializer = new JsonSerializer();
                // Serializamos el objeto directamente en el stream de datos
                serializer.Serialize(file, confs);
            }
        }
    }
}
Now I am able to serialize the list and deserialize it, thanks anyway for the answers you posted since after reading them I found the ilumination required to solve this.
Thank you all, sincerely.
