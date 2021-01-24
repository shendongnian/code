 c#
public XmlNode Data {get;set;}
and run the "what to do with `Data`?" as a second step, once you can look at `MsgType`.
Complete example:
 c#
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
static class P
{
    static void Main()
    {
        const string xml = @"<Foo>
<Msg>
    <MsgType>0</MsgType>
    <Data>Some text</Data>
</Msg>
<Msg>
    <MsgType>1</MsgType>
    <Data>
        <Document>
            <Type>PDF</Type>
            .....
        </Document>
    </Data>
</Msg>
</Foo>";
        var fooSerializer = new XmlSerializer(typeof(Foo));
        var docSerializer = new XmlSerializer(typeof(Document));
        var obj = (Foo)fooSerializer.Deserialize(new StringReader(xml));
        foreach (var msg in obj.Messages)
        {
            switch (msg.MessageType)
            {
                case 0:
                    var text = msg.Data.InnerText;
                    Console.WriteLine($"text: {text}");
                    break;
                case 1:
                    var doc = (Document)docSerializer.Deserialize(new XmlNodeReader(msg.Data));
                    Console.WriteLine($"document of type: {doc.Type}");
                    break;
            }
            Console.WriteLine();
        }
    }
}
public class Foo
{
    [XmlElement("Msg")]
    public List<Message> Messages { get; } = new List<Message>();
}
public class Message
{
    [XmlElement("MsgType")]
    public int MessageType { get; set; }
    public XmlNode Data { get; set; }
}
public class Document
{
    public string Type { get; set; }
}
