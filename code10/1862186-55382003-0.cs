    using (FileStream output = new FileStream(@"simpleToc.pdf", FileMode.Create, FileAccess.Write))
    using (Document document = new Document(PageSize.A4))
    {
        PdfWriter writer = PdfWriter.GetInstance(document, output);
        document.Open();
        Chunk leader = new Chunk(new DottedLineSeparator(), 400);
        Paragraph p = new Paragraph("Terms and Conditions");
        p.Add(leader);
        p.Add("4");
        document.Add(p);
        p = new Paragraph("Dental");
        p.Add(leader);
        p.Add("6");
        document.Add(p);
        p = new Paragraph("Vision");
        p.Add(leader);
        p.Add("7");
        document.Add(p);
        p = new Paragraph("Neighborhood Pharmacy");
        p.Add(leader);
        p.Add("8");
        document.Add(p);
        p = new Paragraph("Teladoc");
        p.Add(leader);
        p.Add("9");
        document.Add(p);
        p = new Paragraph("Retail Health Clinics");
        p.Add(leader);
        p.Add("11");
        document.Add(p);
        p = new Paragraph("Counseling Services");
        p.Add(leader);
        p.Add("12");
        document.Add(p);
        p = new Paragraph("Medical Bill Saver\u2122");
        p.Add(leader);
        p.Add("13");
        document.Add(p);
        p = new Paragraph("Vitamins");
        p.Add(leader);
        p.Add("14");
        document.Add(p);
    }
