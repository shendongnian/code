    using System;
    using System.Xml;
    using System.Xml.XPath;
    using System.Text;
    using System.IO;
    using System.IO.Packaging;
    
    // [...]
    // Call like this: createPackageFromWordOpenXML(wordEditor.WordOpenXML, @"C:\outputFiles\testOut.docx");
    
    /// <summary>
    /// Creates a ZIP package (ie. Word's .docx format) from a WordOpenXML string, which is saved to the file at the path specified.
    /// </summary>
    /// <param name="wordOpenXML">The WordOpenXML string to get the ZIP package data from.</param>
    /// <param name="filePath">The path of the file to save the ZIP package to.</param>
    private void createPackageFromWordOpenXML(string wordOpenXML, string filePath)
    {
        string packageXmlns = "http://schemas.microsoft.com/office/2006/xmlPackage";
        Package newPkg = System.IO.Packaging.ZipPackage.Open(filePath, FileMode.Create);
        try
        {
            XPathDocument xpDocument = new XPathDocument(new StringReader(wordOpenXML));
            XPathNavigator xpNavigator = xpDocument.CreateNavigator();
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xpNavigator.NameTable);
            nsManager.AddNamespace("pkg", packageXmlns);
            XPathNodeIterator xpIterator = xpNavigator.Select("//pkg:part", nsManager);
            while (xpIterator.MoveNext())
            {
                Uri partUri = new Uri(xpIterator.Current.GetAttribute("name", packageXmlns), UriKind.Relative);
                PackagePart pkgPart = newPkg.CreatePart(partUri, xpIterator.Current.GetAttribute("contentType", packageXmlns));
                // Set this package part's contents to this XML node's inner XML, sans its surrounding xmlData element.
                string strInnerXml = xpIterator.Current.InnerXml
                    .Replace("<pkg:xmlData xmlns:pkg=\"" + packageXmlns + "\">", "")
                    .Replace("</pkg:xmlData>", "");
                byte[] buffer = Encoding.UTF8.GetBytes(strInnerXml);
                pkgPart.GetStream().Write(buffer, 0, buffer.Length);
            }
            newPkg.Flush();
        }
        finally
        {
            newPkg.Close();
        }
    }
