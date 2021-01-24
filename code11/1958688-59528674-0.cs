    string xmlFile = @"C:\wordDoc\movies.xml";
    string docxFile = @"C:\wordDoc\test.docx";
    
    var document = new DocumentModel();
    
    var section = new Section(document);
    document.Sections.Add(section);
    
    var table = new Table(document);
    section.Blocks.Add(table);
    
    foreach (var xmlRow in XDocument.Load(xmlFile).Descendants("Movie"))
        table.Rows.Add(
            new TableRow(document,
                new TableCell(document,
                    new Paragraph(document, xmlRow.Element("Name").Value)),
                new TableCell(document,
                    new Paragraph(document, xmlRow.Element("Released").Value))));
    
    table.TableFormat.Borders.SetBorders(MultipleBorderTypes.All, BorderStyle.Double, Color.Red, 2);
    
    document.Save(docxFile);
