    uing System;
    using System.Runtime.Serialization;
    using System.IO;
    
    public class Test
    {
     public class Root
      {
        private string mElement2 = string.Empty; // you can initialize your new property and you    dot need any advance stuff
        public String Element1 { get; set; }    
        public String Element2 { get{return mElement2;} set{mElement2 = value;} }
      }
    
      public static void Main(string[] s)
      {
        Test_When_Original_Object_Was_Serialized_With_One_Element();
        Test_When_Original_Object_Was_Serialized_With_Two_Element();
        Console.ReadLine();
      }
    
      private static void TestReadingObjects(string xml)
      {
        System.Xml.Serialization.XmlSerializer xmlSerializer =
        new System.Xml.Serialization.XmlSerializer(typeof(Root));
    
    
        System.IO.Stream stream = new MemoryStream();
        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
        Byte[] bytes = encoding.GetBytes(xml);
        stream.Write(bytes, 0, bytes.Length);
        stream.Position = 0;
        Root r = (Root)xmlSerializer.Deserialize(stream);
    
        Console.WriteLine(string.Format("Element 1 = {0}", r.Element1));
    
        Console.WriteLine(string.Format("Element 2 ={0}", r.Element2 == null ? "Null" : r.Element2));
      }
      private static void Test_When_Original_Object_Was_Serialized_With_One_Element()
      {
        TestReadingObjects(@"<Root>   <Element1>1</Element1>   </Root>");
      }
    
      private static void Test_When_Original_Object_Was_Serialized_With_Two_Element()
      {
        TestReadingObjects(@"<Root>   <Element1>1</Element1> <Element2>2</Element2>   </Root>");
      }
    }
