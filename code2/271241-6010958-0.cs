    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Microsoft.SharePoint;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Wordprocessing;
    class Program
    {
        static void Main(string[] args)
        {
            string siteUrl = "http://localhost";
            using (SPSite spSite = new SPSite(siteUrl))
            {
                Console.WriteLine("Querying for Test.docx");
                SPList list = spSite.RootWeb.Lists["Shared Documents"];
                SPQuery query = new SPQuery();
                query.ViewFields = @"<FieldRef Name='FileLeafRef' />";
                query.Query =
                  @"<Where>
                      <Eq>
                        <FieldRef Name='FileLeafRef' />
                        <Value Type='Text'>Test.docx</Value>
                      </Eq>
                    </Where>";
                SPListItemCollection collection = list.GetItems(query);
                if (collection.Count != 1)
                {
                    Console.WriteLine("Test.docx not found");
                    Environment.Exit(0);
                }
                Console.WriteLine("Opening");
                SPFile file = collection[0].File;
                byte[] byteArray = file.OpenBinary();
                using (MemoryStream memStr = new MemoryStream())
                {
                    memStr.Write(byteArray, 0, byteArray.Length);
                    using (WordprocessingDocument wordDoc =
                        WordprocessingDocument.Open(memStr, true))
                    {
                        Document document = wordDoc.MainDocumentPart.Document;
                        Paragraph firstParagraph = document.Body.Elements<Paragraph>()
                            .FirstOrDefault();
                        if (firstParagraph != null)
                        {
                            Paragraph testParagraph = new Paragraph(
                                new Run(
                                    new Text("Test")));
                            firstParagraph.Parent.InsertBefore(testParagraph,
                                firstParagraph);
                        }
                    }
                    Console.WriteLine("Saving");
                    string linkFileName = file.Item["LinkFilename"] as string;
                    file.ParentFolder.Files.Add(linkFileName, memStr, true);
                }
            }
        }
    }
