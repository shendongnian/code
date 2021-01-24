    Document document = new Document();
    // Create a template object and add a page numbering label
    Template template = new Template();
    template.Elements.Add(new PageNumberingLabel("%%SP%% of %%ST%%", 0, 680, 512, 12, Font.Helvetica, 12, TextAlign.Center));
    // Begin the first section
    document.Sections.Begin(NumberingStyle.RomanLowerCase);
    // Add two pages
    document.Pages.Add(new Page()); //Page 1
    document.Pages.Add(new Page()); //Page 2
    // Begin the second section
    document.Sections.Begin(NumberingStyle.Numeric, template);
    // Add three pages
    document.Pages.Add(new Page()); //Page 3
    document.Pages.Add(new Page()); //page 4
    document.Pages.Add(new Page()); //page 5
    // Save the PDF
    document.Draw("output.pdf");
