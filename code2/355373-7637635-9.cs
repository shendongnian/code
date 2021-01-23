    protected void Page_Load(object sender, EventArgs e)
    {
        Thread.Sleep(10000);//Give the sensation that the pdf file takes long to generate
        //replace line below with actual code that generates the PDF file
        byte[] pdf = File.ReadAllBytes(Server.MapPath(@"~/file.pdf"));
        Response.AddHeader("Content-disposition", "attachment; filename=report.pdf");
        Response.ContentType = "application/octet-stream";
        Response.BinaryWrite(pdf);
        Response.Flush();
        Response.End();        
    }
