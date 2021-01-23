    public class Test
    {
      public int group1_attr1;
      public int group1_attr2;
      public int group2_attr1;
    }
    class Program
    {
      static void Main(string[] args)
      {
         System.Xml.Serialization.XmlAttributes xa = 
            new System.Xml.Serialization.XmlAttributes();
         xa.XmlIgnore = true;
         System.Xml.Serialization.XmlAttributeOverrides xo1 = 
            new System.Xml.Serialization.XmlAttributeOverrides();
         xo1.Add(typeof(Test), "group1_attr1", xa);
         xo1.Add(typeof(Test), "group1_attr2", xa);
         System.Xml.Serialization.XmlAttributeOverrides xo2 = 
            new System.Xml.Serialization.XmlAttributeOverrides();
         xo2.Add(typeof(Test), "group2_attr1", xa);
         System.Xml.Serialization.XmlSerializer xs1 = 
            new System.Xml.Serialization.XmlSerializer(typeof(Test), xo1);
         System.Xml.Serialization.XmlSerializer xs2 = 
            new System.Xml.Serialization.XmlSerializer(typeof(Test), xo2);
         Test t1 = new Test();
         t1.group1_attr1 = 1;
         t1.group1_attr2 = 2;
         t1.group2_attr1 = 3;
         using (System.IO.StringWriter sw = new System.IO.StringWriter())
         {
            xs1.Serialize(sw, t1);
            Console.WriteLine(sw);
         }
         using (System.IO.StringWriter sw = new System.IO.StringWriter())
         {
            xs2.Serialize(sw, t1);
            Console.WriteLine(sw);
         }
      }
    }
