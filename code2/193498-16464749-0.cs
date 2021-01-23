    protected void PrintButton_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        Response.ContentType = "application/pdf";
        using (var document = new Document())
        {
            PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();
            document.Add(new Paragraph("Hello PDF!"));
            document.Close();
        }
    }
