using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
namespace XsdTypes
{
    public class NormalizedString : IXmlSerializable
    {
        public const char CR = '\u000d';
        public const char LF = '\u000a';
        public const char SPACE = '\u0020';
        public const char TAB = '\u0009';
        protected string value = null;
        public NormalizedString() { }
        public NormalizedString(NormalizedString value)
        {
            this.value = value.value;
        }
        public NormalizedString(String value)
        {
            this.value = NormalizeWhitespace(value);
        }
        public static string NormalizeWhitespace(string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                value = value.Replace(CR, SPACE).Replace(LF, SPACE).Replace(TAB, SPACE);
            }
            return value;
        }
        #region Class overrides
        public override string ToString()
        {
            return value;
        }
        #endregion
        #region IXmlSerializable
        XmlSchema IXmlSerializable.GetSchema()
        {
            return (null);
        }
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            //TODO: This could be null
            value = NormalizeWhitespace(reader.ReadString());
            reader.Read();
        }
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteString(NormalizeWhitespace(value));
        }
        #endregion
    }
}
There's a lot more work implementing a generally useful class (`ICloneable`, `IComparable`, `IConvertible`, `IEquatable`, implicit operators, etc), but the above is sufficient to deserialize and serialize the following class correctly:
    [XmlRoot("Root")]
    public class Root
    {
        [XmlElement(IsNullable = true)]
        public NormalizedString CarriageReturns;
        [XmlElement(IsNullable = true)]
        public NormalizedString Linefeeds;
        [XmlElement(IsNullable = true)]
        public NormalizedString Spaces;
        [XmlElement(IsNullable = true)]
        public NormalizedString Tabs;
    }
This seems a lot simpler than adding custom getters and setters every place I want an `xs:normalizedString` element.
> Be aware: If you try to decorate one of these NormalizedString fields with `[XmlElement(DataType="normalizedString")]` (or `DataType=anything`, really) you will get a run time exception:
System.Xml.Serialization.XmlReflectionImporter.ImportTypeMapping(TypeModel model, String ns, ImportContext context, String dataType, XmlAttributes a, Boolean repeats, Boolean openModel, RecursionLimiter limiter)
InvalidOperationException : 'normalizedString' is an invalid value for the XmlElementAttribute.DataType property. The property may only be specified for primitive types.
The following set of NUnit3 tests exercise XML deserialization and serialization:
// Install-Package NUnit
// Install-Package NUnit3TestAdapter
using NUnit.Framework;
using System.IO;
using System.Text;
using System.Xml.Serialization;
namespace XsdTypes.NormalizedStringTests.IXmlSerializable
{
    [XmlRoot("Root")]
    public class Root
    {
        [XmlElement(IsNullable = true)]
        public NormalizedString CarriageReturns;
        [XmlElement(IsNullable = true)]
        public NormalizedString Linefeeds;
        [XmlElement(IsNullable = true)]
        public NormalizedString Spaces;
        [XmlElement(IsNullable = true)]
        public NormalizedString Tabs;
    }
    [TestFixture]
    public class NormalizedStringDeserializationTests
    {
        public Root root;
        [SetUp]
        public void SetUp()
        {
            var xml =
                "<Root>\r\n" +
                " <CarriageReturns> returns\u000d\u000dreturns </CarriageReturns>\r\n" +
                " <Linefeeds> linefeeds\u000a\u000alinefeeds </Linefeeds>\r\n" +
                " <Spaces> spaces\u0020\u0020spaces </Spaces>\r\n" +
                " <Tabs> tabs\u0009\u0009tabs </Tabs>\r\n" +
                "</Root>\r\n";
            Deserialize(xml);
        }
        private void Deserialize(string xml)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                var serializer = new XmlSerializer(typeof(Root));
                root = (Root)serializer.Deserialize(stream);
            }
        }
        [Test]
        public void TestCarriageReturns()
        {
            string actual = root.CarriageReturns.ToString();
            Assert.That(actual, Is.EqualTo(" returns  returns "));
        }
        [Test]
        public void TestLinefeeds()
        {
            string actual = root.Linefeeds.ToString();
            Assert.That(actual, Is.EqualTo(" linefeeds  linefeeds "));
        }
        [Test]
        public void TestSpaces()
        {
            string actual = root.Spaces.ToString();
            Assert.That(actual, Is.EqualTo(" spaces  spaces "));
        }
        [Test]
        public void TestTabs()
        {
            string actual = root.Tabs.ToString();
            Assert.That(actual, Is.EqualTo(" tabs  tabs "));
        }
    }
    [TestFixture]
    public class NormalizedStringSerializationTests
    {
        string xml;
        [SetUp]
        public void SetUp()
        {
            var root = new Root()
            {
                CarriageReturns = new NormalizedString(" returns\u000d\u000dreturns "),
                Linefeeds = new NormalizedString(" linefeeds\u000d\u000dlinefeeds "),
                Spaces = new NormalizedString(" spaces\u000d\u000dspaces "),
                Tabs = new NormalizedString(" tabs\u000d\u000dtabs ")
            };
            Serialize(root);
        }
        private void Serialize(Root root)
        {
            using (var stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof(Root));
                serializer.Serialize(stream, root);
                xml = Encoding.UTF8.GetString(stream.ToArray());
            }
        }
        [Test]
        public void TestCarriageReturns()
        {
            Assert.That(xml, Does.Contain("<CarriageReturns> returns  returns </CarriageReturns>"));
        }
        [Test]
        public void TestLinefeeds()
        {
            Assert.That(xml, Does.Contain("<Linefeeds> linefeeds  linefeeds </Linefeeds>"));
        }
        [Test]
        public void TestNullables()
        {
            Serialize(new Root());
            Assert.That(xml, Does.Contain("<CarriageReturns xsi:nil=\"true\" />"));
            Assert.That(xml, Does.Contain("<Linefeeds xsi:nil=\"true\" />"));
            Assert.That(xml, Does.Contain("<Spaces xsi:nil=\"true\" />"));
            Assert.That(xml, Does.Contain("<Tabs xsi:nil=\"true\" />"));
        }
        [Test]
        public void TestSpaces()
        {
            Assert.That(xml, Does.Contain("<Spaces> spaces  spaces </Spaces>"));
        }
        [Test]
        public void TestTabs()
        {
            Assert.That(xml, Does.Contain("<Tabs> tabs  tabs </Tabs>"));
        }
    }
}
HTH.
