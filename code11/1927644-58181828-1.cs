    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication132
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME, settings);
                XmlSerializer serializer = new XmlSerializer(typeof(Project));
                Project project = new Project();
                serializer.Serialize(writer, project);
            }
        }
        [XmlRoot("PROJECT")]
        public class Project
        {
            [XmlAttribute]
            public string name { get; set; }
            [XmlElement("CLASS")]
            public List<cClass> classes { get; set; }
            public Project()
            {
                name = "test project xml";
                classes = new List<cClass>() {
                    new cClass() {
                        name = "class1",
                        class_id = 1,
                        vars = new List<Var>() {
                            new Var() { 
                                name = "var name 1",
                                description = "var description",
                                var_id = 1,
                                elements = new List<Element>() {
                                    new Element() {
                                       name = "element name 1",
                                       description = "element description",
                                       element_id = 1
                                    },
                                    new Element() {
                                       name = "element name 2",
                                       description = "element description",
                                       element_id = 2,
                                       elements = new List<Element>() {
                                           new Element() {
                                               name = "element name 3",
                                               description = "element description",
                                               element_id = 3
                                           }
                                       }
                                    },
                                    new Element() {
                                       name = "element name 4",
                                       description = "element description",
                                       element_id = 4,
                                       elements = new List<Element>() {
                                            new Element() {
                                               name = "element name 5",
                                               description = "element description",
                                               element_id = 5,
                                               elements = new List<Element>() {
                                                   new Element() {
                                                       name = "element name 6",
                                                       description = "element description",
                                                       element_id = 6
                                                   }
                                               }
                                            }
                                       }
                                    },
                                    new Element() {
                                       name = "element name 7",
                                       description = "element description",
                                       element_id = 7,
                                       enums = new List<Enm>() {
                                           new Enm() {
                                              name = "option 1",
                                              value = 1
                                           },
                                           new Enm() {
                                              name = "option 2",
                                              value = 2
                                           },
                                           new Enm() {
                                              name = "option 3",
                                              value = 3
                                           }
                                       }
                                    }
                                }
                            },
                            new Var() { 
                                name = "var name 2",
                                description = "var description",
                                var_id = 2,
                                elements = new List<Element>() {
                                    new Element() {
                                       name = "element name 8",
                                       description = "element description",
                                       element_id = 8
                                    }
                                }
                            }
                       }
                    }
                };
            }
        }
        public class cClass
        {
            [XmlAttribute]
            public string name { get; set; }
            [XmlAttribute]
            public int class_id;
            [XmlElement("VAR")]
            public List<Var> vars;
        }
        public class Var
        {
            [XmlAttribute]
            public string name;
            [XmlAttribute]
            public string description;
            [XmlAttribute]
            public int var_id;
            [XmlElement("ELEMENT")]
            public List<Element> elements;
        }
        public struct Element
        {
            [XmlAttribute]
            public string name;
            [XmlAttribute]
            public string description;
            [XmlAttribute]
            public int element_id;
            [XmlElement("ELEMENT")]
            public List<Element> elements;
            [XmlElement("EMNU")]
            public List<Enm> enums;
        }
        public struct Enm
        {
            [XmlAttribute]
            public string name;
            [XmlAttribute]
            public int value;
        }
    }
