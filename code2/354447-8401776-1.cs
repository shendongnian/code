    <product xmlns="http://www.example.com/schemas/v0.1">
      <size name="S" size.att="">
        <stock>
          <a.el a.att=""></a.el>
          <b.el b.att="" b.att2=""></b.el>
        </stock>
      </size>
      <size name="" size.att="">
        <stock>
          <a.el a.att="a.value" />
          <b.el b.att="" b.att2=""></b.el>
        </stock>
      </size>
      <size name="" size.att="">
        <stock>
            10
            <b.el b.att="b.value" b.att2="" /><a.el a.att=""></a.el></stock>
      </size>
      <size size.att="size.value" name="e">
        <stock>
            12
            <b.el b.att2="b.value2" b.att="" /><a.el a.att=""></a.el></stock>
      </size>
    </product>
----------
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                XDocument xDoc = XDocument.Load("test.xml");
                XNamespace ns = xDoc.Root.Name.Namespace;
    
                var mgr = new XmlNamespaceManager(new NameTable());
                mgr.AddNamespace("ns", ns.ToString());
    
                var elements = xDoc.XPathSelectElements("/ns:product/ns:size", mgr);
    
                Descriptor desc = Descriptor.InferFrom(elements);
    
                desc.Normalize(elements);
                Console.Write(xDoc.ToString());
            }
        }
    
        public class Descriptor
        {
            private readonly IList<XName> _attributeNames = new List<XName>();
            private readonly IDictionary<XName, Descriptor> _elementDescriptors = new Dictionary<XName, Descriptor>();
    
            public XName Name { get; private set; }
            public IEnumerable<XName> AttributeNames { get { return _attributeNames; } }
            public IEnumerable<KeyValuePair<XName, Descriptor>> ElementDescriptors { get { return _elementDescriptors;  } }
    
            private void UpdateNameFrom(XElement element)
            {
                if (Name == null)
                {
                    Name = element.Name;
                    return;
                }
    
                if (element.Name == Name)
                    return;
    
                throw new InvalidOperationException();
            }
    
            private void Add(XAttribute att)
            {
                XName name = att.Name;
                if (_attributeNames.Contains(name))
                    return;
                
                _attributeNames.Add(name);
            }
    
            public static Descriptor InferFrom(IEnumerable<XElement> elements)
            {
                var desc = new Descriptor();
    
                foreach (var element in elements)
                    InferFromInternal(element, desc);
    
                return desc;
            }
    
            private static void InferFromInternal(XElement element, Descriptor desc)
            {
                desc.UpdateNameFrom(element);
    
                foreach (var att in element.Attributes())
                    desc.Add(att);
    
                foreach (var subElement in element.Elements())
                    desc.Add(subElement);
            }
    
            private void Add(XElement subElement)
            {
                Descriptor desc;
                if (_elementDescriptors.ContainsKey(subElement.Name))
                    desc = _elementDescriptors[subElement.Name];
                else
                {
                    desc = new Descriptor();
                    _elementDescriptors.Add(subElement.Name, desc);
                }
    
                InferFromInternal(subElement, desc);
            }
    
            public void Normalize(IEnumerable<XElement> elements)
            {
                foreach (var element in elements)
                    NormalizeInternal(element);
            }
    
            private void NormalizeInternal(XElement element)
            {
                if (element.Name != Name)
                    throw new InvalidOperationException();
    
                foreach (var attribute in AttributeNames)
                {
                    var att = element.Attribute(attribute);
    
                    if (att != null)
                        continue;
    
                    element.Add(new XAttribute(attribute, string.Empty));
                }
    
                foreach (var attribute in _elementDescriptors)
                {
                    XElement el = element.Element(attribute.Key);
    
                    if (el == null)
                    {
                        el = new XElement(attribute.Key, string.Empty);
                        element.Add(el);
                    }
    
                    attribute.Value.NormalizeInternal(el);
                }
            }
        }
    }
