    public class SomeClass: IXmlSerializable
    {
       private double someValue;
       public double SomeValue 
       {
          get{ return someValue;}
          set{ someValue = value;}
       }
       public void WriteXml (XmlWriter writer)
       {
          writer.WriteString(someValue * 10);
       }
       public void ReadXml (XmlReader reader)
       {
          someValue = Convert.ToDouble(reader.ReadString()) / 10;
        }
    }
