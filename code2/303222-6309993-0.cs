	using System;
	using System.IO;
	using System.Xml;
	using System.Xml.Serialization;
	using System.Collections.Generic;
	using System.Windows.Forms;
	
	
	//Serialize an object to disk (properties must be public):
	
	public string Serialize(Object Input, string OutFile)
    {
        System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
        XmlSerializer XML = new XmlSerializer(Input.GetType());
        XML.Serialize(memoryStream, Input);
        
        memoryStream.Flush();
        memoryStream.Position = 0;
        if (!string.IsNullOrEmpty(OutFile))
        {
            using (FileStream fileStream = new FileStream(OutFile, FileMode.Create))
            {
                byte[] data = memoryStream.ToArray();
                fileStream.Write(data, 0, data.Length);
                fileStream.Close();
            }
        }
        return new System.IO.StreamReader(memoryStream).ReadToEnd();
    }
	
	
	//Deserialize from a serialized file:
	
	    public object DeserializeFile(Type ObjectType, string FileName)
    {
        Type type = typeof(object);
        if (ObjectType != null)
        { type = ObjectType; }
        using (FileStream fileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read))
        {
            StreamReader sr = new StreamReader(fileStream);
            string XML = sr.ReadToEnd();
            XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(type);
            fileStream.Close();
            return xmlSerializer.Deserialize(new StringReader(XML));
        }
    }
	
	CustomObject co = DeserializeFile(typeof(CustomObject), fileName.xml) as CustomObject;
	
