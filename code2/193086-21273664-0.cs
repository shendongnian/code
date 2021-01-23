    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Xml.Schema;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    
    using Microsoft.CSharp;
    
    using NUnit.Framework;
    
    namespace XmlSchemaImporterTest
    {
      [TestFixture]
      public class XsdToClassTests
      {
          // Test for XmlSchemaImporter
          [Test]
          public void XsdToClassTest()
          {
              // identify the path to the xsd
              string xsdFileName = "Account.xsd";
              string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
              string xsdPath = Path.Combine(path, xsdFileName);
    
              // load the xsd
              XmlSchema xsd;
              using(FileStream stream = new FileStream(xsdPath, FileMode.Open, FileAccess.Read))
              {
                  xsd = XmlSchema.Read(stream, null);
              }
              Console.WriteLine("xsd.IsCompiled {0}", xsd.IsCompiled);
    
              XmlSchemas xsds = new XmlSchemas();
              xsds.Add(xsd);
              xsds.Compile(null, true);
              XmlSchemaImporter schemaImporter = new XmlSchemaImporter(xsds);
    
              // create the codedom
              CodeNamespace codeNamespace = new CodeNamespace("Generated");
              XmlCodeExporter codeExporter = new XmlCodeExporter(codeNamespace);
    
              List maps = new List();
              foreach(XmlSchemaType schemaType in xsd.SchemaTypes.Values)
              {
                  maps.Add(schemaImporter.ImportSchemaType(schemaType.QualifiedName));
              }
              foreach(XmlSchemaElement schemaElement in xsd.Elements.Values)
              {
                  maps.Add(schemaImporter.ImportTypeMapping(schemaElement.QualifiedName));
              }
              foreach(XmlTypeMapping map in maps)
              {
                  codeExporter.ExportTypeMapping(map);
              }
    
              RemoveAttributes(codeNamespace);
    
              // Check for invalid characters in identifiers
              CodeGenerator.ValidateIdentifiers(codeNamespace);
    
              // output the C# code
              CSharpCodeProvider codeProvider = new CSharpCodeProvider();
    
              using(StringWriter writer = new StringWriter())
              {
                  codeProvider.GenerateCodeFromNamespace(codeNamespace, writer, new CodeGeneratorOptions());
                  Console.WriteLine(writer.GetStringBuilder().ToString());
              }
    
              Console.ReadLine();
          }
    
          // Remove all the attributes from each type in the CodeNamespace, except
          // System.Xml.Serialization.XmlTypeAttribute
          private void RemoveAttributes(CodeNamespace codeNamespace)
          {
              foreach(CodeTypeDeclaration codeType in codeNamespace.Types)
              {
                  CodeAttributeDeclaration xmlTypeAttribute = null;
                  foreach(CodeAttributeDeclaration codeAttribute in codeType.CustomAttributes)
                  {
                      Console.WriteLine(codeAttribute.Name);
                      if(codeAttribute.Name == "System.Xml.Serialization.XmlTypeAttribute")
                      {
                          xmlTypeAttribute = codeAttribute;
                      }
                  }
                  codeType.CustomAttributes.Clear();
                  if(xmlTypeAttribute != null)
                  {
                      codeType.CustomAttributes.Add(xmlTypeAttribute);
                  }
              }
          }
      }
    }
