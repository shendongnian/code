 c#
[XmlRoot("Data")]
public class MyData {
    [XmlArray("Albums")]
    [XmlArrayItem("Album")]
    public List<Album> Albums {get;} = new List<Album>();
    [XmlArray("Images")]
    [XmlArrayItem("Image")]
    public List<string> Images {get;} = new List<string>();
    [XmlArray("Formats")]
    [XmlArrayItem("Format")]
    public List<string> Formats {get;} = new List<string>();
}
public class Album {
    [XmlElement("Image")]
    public List<string> Images {get;} = new List<string>();
}
usage:
 c#
var serializer = new XmlSerializer(typeof(MyData));
var obj = (MyData)serializer.Deserialize(source);
And if your real xml is more complex: just copy the xml into the clipboard, and edit => paste special => paste xml as classes
Also there are many sites/tools that let you convert your xml to c# code.
https://xmltocsharp.azurewebsites.net/
