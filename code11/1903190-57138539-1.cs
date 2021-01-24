    public FileResult GetPDF(string statementHTML)
    {
        var fileByte = System.IO.File.ReadAllBytes(@"xxx\Test.pdf");
        return File(fileByte, "apllication/pdf", "Test.pdf");
    }
