    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ParseSchema
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xsd";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Root;
                XNamespace ns = root.GetNamespaceOfPrefix("xs");
                Element element = new Element(null, root, ns, null);
                SimpleContent.LinkParents();
                Element.LinkParents();
            }
        }
        public class Element
        {
            public static List<Element> elements = new List<Element>();  // needed to link to parent
            public XNamespace ns { get; set; }
            SchemaType schemaType { get; set; }
            public Dictionary<string, object> typeDictionary = null;
            public Dictionary<string, string> attributeDictionary = null;
            public Element parent { get; set; }
            public string annotation { get; set; }
            public Element(SchemaType parentSchema, XElement parentXElement, XNamespace ns, Element parentElement)
            {
                XElement xAnnotation;
                XElement xElement;
                this.parent = parentElement;
                this.ns = ns;
                Element.elements.Add(this);
     
                List<XElement> xTypes = parentXElement.Elements().Where(x => (x.Name.LocalName == "simpleType") | (x.Name.LocalName == "complexType")).ToList();
                foreach (XElement xType in xTypes)
                {
                    string name = (string)xType.Attribute("name");
                    if (typeDictionary == null) typeDictionary = new Dictionary<string, object>();
                    SchemaType newType = new SchemaType(xType, ns, this);
                    typeDictionary.Add(name, newType);
                }
                xElement = parentXElement.Element(ns + "element");
                attributeDictionary = xElement.Attributes()
                    .GroupBy(x => x.Name.LocalName, y => (string)y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                xAnnotation = xElement.Element(ns + "annotation");
                if (annotation != null) annotation = (string)xAnnotation.Element(ns + "documentation");
            }
            public static void LinkParents()
            {
                foreach (Element element in elements)
                {
                    string stringType = "";
                    Boolean foundAttributeType = element.attributeDictionary.TryGetValue("type", out stringType);
                    if (foundAttributeType && !stringType.StartsWith("xs:"))
                    {
                        Element parent = element;
                        object obj = null;
                        while (parent != null)
                        {
                            if (parent.typeDictionary != null)
                            {
                                Boolean foundType = parent.typeDictionary.TryGetValue(stringType, out obj);
                                if (foundType)
                                {
                                    element.schemaType = (SchemaType)obj;
                                    break;
                                }
                            }
                            parent = parent.parent;
                        }
                    }
                }
            }
        }
        public class SchemaType
        {
            public string name { get; set; }
            public string simpleComplex { get; set; }
            public string annotation { get; set; }
            public List<Attribute> attributes { get; set; }
            public Restrictions restriction { get; set; }
            public SimpleContent simpleContent { get; set; }
            public Element parentElement { get; set; }
            public List<Element> elements { get; set; }
            public SchemaType(XElement schemaType, XNamespace ns, Element parentElement)
            {
                simpleComplex = schemaType.Name.LocalName;
                foreach (XElement child in schemaType.Elements())
                {
                    switch (child.Name.LocalName)
                    {
                        case "annotation":
                            annotation = (string)child.Element(ns + "documentation");
                            break;
                        case "attribute":
                            Attribute newAttribute = new Attribute(child, ns, parentElement);
                            if (attributes == null) attributes = new List<Attribute>();
                            attributes.Add(newAttribute);
                            break;
                        case "restriction":
                            restriction = new Restrictions(child, ns);
                            break;
                        case "sequence":
                            elements = child.Elements(ns + "element").Select(x => new Element(this, child, ns, parentElement)).ToList();
                            break;
                        case "simpleContent" :
                            simpleContent = new SimpleContent(child, ns, parentElement);
                            break;
                        default:
                            break;
                    }
                }
            }
            
        }
        public class Restrictions
        {
            string baseType { get; set; }
            Dictionary<string, List<string>> enumerations { get; set; }
            public Restrictions(XElement xRestriction, XNamespace ns)
            {
                baseType = (string)xRestriction.Attribute("base");
                enumerations = xRestriction.Elements()
                    .GroupBy(x => x.Name.LocalName, y => (string)y.Attribute("value"))
                    .ToDictionary(x => x.Key, y => y.ToList());
            }
        }
        public class Attribute
        {
            public Dictionary<string, string> attributeDictionary;
            public string annotation { get; set; }
            public SchemaType schemaType { get; set; }
            public Attribute(XElement attribute, XNamespace ns, Element parentElement)
            {
                attributeDictionary = attribute.Attributes()
                    .GroupBy(x => x.Name.LocalName, y => (string)y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                XElement xAnnotation = attribute.Element(ns + "annotation");
                if (annotation != null) annotation = (string)xAnnotation.Element(ns + "documentation");
                List<XElement> xSchemaType = attribute.Elements().Where(x => (x.Name.LocalName == "simpleType") | (x.Name.LocalName == "complexType")).ToList();
                if(xSchemaType.Count > 0) schemaType = new SchemaType(xSchemaType.FirstOrDefault(), ns, parentElement);
            }
        }
        public class SimpleContent
        {
            public static List<SimpleContent> contents = new List<SimpleContent>();  // needed to link to parent
            public string baseType { get; set; }
            public List<Attribute> attributes { get; set; }
            public SchemaType schemaType { get; set; }
            public Element parentElement { get; set; }
            public SimpleContent(XElement content, XNamespace ns, Element parentElement)
            {
                this.parentElement = parentElement;
                contents.Add(this);
                XElement extension = content.Element(ns + "extension");
                if (extension != null)
                {
                    baseType = (string)extension.Attribute("base");
                    List<XElement> xAttributes = extension.Elements(ns + "attribute").ToList();
                    foreach (XElement xAttribute in xAttributes)
                    {
                        if (attributes == null) attributes = new List<Attribute>();
                        Attribute newAttribute = new Attribute(xAttribute, ns, parentElement);
                        attributes.Add(newAttribute);
                    }
                }
            }
            public static void LinkParents()
            {
                foreach (SimpleContent content in contents)
                {
                    if (!content.baseType.StartsWith("xs:"))
                    {
                        Element parent = content.parentElement;
                        object obj = null;
                        while (parent != null)
                        {
                            Boolean foundType = parent.typeDictionary.TryGetValue(content.baseType, out obj);
                            if (foundType)
                            {
                                content.schemaType = (SchemaType)obj;
                            }
                            parent = parent.parent;
                        }
                    }
                }
            }
        }
    }
