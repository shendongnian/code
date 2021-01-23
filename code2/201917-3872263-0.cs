    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                Pages pages = new Pages();
                pages.PublishedPages.Add(
                    new PublishedPage()
                    {
                        PageGuid = Guid.NewGuid().ToString(),
                        SearchableProperties = new List<string>()
                        {
                            "Foo",
                            "Bar",
                        }
                    });
                pages.PublishedPages.Add(
                    new PublishedPage()
                    {
                        PageGuid = Guid.NewGuid().ToString(),
                        SearchableProperties = new List<string>()
                        {
                        "Tic",
                        "Tac",
                        "Toe",
                        }
                    });
                pages.DeletedPages.Add(
                    new DeletedPage()
                    {
                        PageGuid = Guid.NewGuid().ToString(),
                    });
                pages.DeletedPages.Add(
                    new DeletedPage()
                    {
                        PageGuid = Guid.NewGuid().ToString(),
                    });
                pages.MovedPages.Add(
                    new MovedPage()
                    {
                        PageGuid = Guid.NewGuid().ToString(),
                        OldParentGuid = Guid.NewGuid().ToString(),
                        NewParentGuid = Guid.NewGuid().ToString(),
                    });
                pages.MovedPages.Add(
                    new MovedPage()
                    {
                        PageGuid = Guid.NewGuid().ToString(),
                        OldParentGuid = Guid.NewGuid().ToString(),
                        NewParentGuid = Guid.NewGuid().ToString(),
                    });
                Console.WriteLine(SerializeObject(pages));
            }
    
            /// <summary>
            /// To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.
            /// </summary>
            /// <param name="characters">Unicode Byte Array to be converted to String</param>
            /// <returns>String converted from Unicode Byte Array</returns>
            private static string UTF8ByteArrayToString(Byte[] characters)
            {
                UTF8Encoding encoding = new UTF8Encoding();
                string constructedString = encoding.GetString(characters);
                return (constructedString);
            }
    
            /// <summary>
            /// Converts the String to UTF8 Byte array and is used in De serialization
            /// </summary>
            /// <param name="pXmlString"></param>
            /// <returns></returns>
            private static Byte[] StringToUTF8ByteArray(string pXmlString)
            {
                UTF8Encoding encoding = new UTF8Encoding();
                Byte[] byteArray = encoding.GetBytes(pXmlString);
                return byteArray;
            }
    
            /// <summary>
            /// From http://www.dotnetjohn.com/articles.aspx?articleid=173
            /// Method to convert a custom Object to XML string
            /// </summary>
            /// <param name="pObject">Object that is to be serialized to XML</param>
            /// <returns>XML string</returns>
            public static string SerializeObject(Object pObject)
            {
                try
                {
                    string xmlizedString = null;
                    MemoryStream memoryStream = new MemoryStream();
                    XmlSerializer xs = new XmlSerializer(pObject.GetType());
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                    xmlTextWriter.Formatting = Formatting.Indented;
    
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
    
                    xs.Serialize(xmlTextWriter, pObject, ns);
                    memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                    xmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                    return xmlizedString;
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);
                    return null;
                }
            }
        }
    
        [XmlRoot(ElementName="Pages", Namespace="")]
        public class Pages
        {
            public List<PublishedPage> PublishedPages { get; set; }
            public List<MovedPage> MovedPages { get; set; }
            public List<DeletedPage> DeletedPages { get; set; }
    
            public Pages()
            {
                PublishedPages = new List<PublishedPage>();
                MovedPages = new List<MovedPage>();
                DeletedPages = new List<DeletedPage>();
            }
        }
    
        public class PublishedPage
        {
            public string Action { get; set; }
            public string PageGuid { get; set; }
            public List<string> SearchableProperties { get; set; }
    
            public PublishedPage()
            {
                Action = "Published";
                SearchableProperties = new List<string>();
            }
        }
    
        public class DeletedPage
        {
            public string Action { get; set; }
            public string PageGuid { get; set; }
    
            public DeletedPage()
            {
                Action = "Deleted";
            }
        }
    
        public class MovedPage
        {
            public string Action { get; set; }
            public string PageGuid { get; set; }
            public string OldParentGuid { get; set; }
            public string NewParentGuid { get; set; }
    
            public MovedPage()
            {
                Action = "Moved";
            }
        }
    }
