    protected void ExportToPDF(object sender, EventArgs e)
    {
        //Get the data from database into datatable
        string strQuery = "select CustomerID, ContactName, City, PostalCode"     +
            " from customers";
        SqlCommand cmd = new SqlCommand(strQuery);
    DataTable dt = GetData(cmd);
 
    //Create a dummy GridView
    GridView GridView1 = new GridView();
    GridView1.AllowPaging = false;
    GridView1.DataSource = dt;
    GridView1.DataBind();
 
    Response.ContentType = "application/pdf";
    Response.AddHeader("content-disposition",
        "attachment;filename=DataTable.pdf");
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    StringWriter sw = new StringWriter();
    HtmlTextWriter hw = new HtmlTextWriter(sw);
    GridView1.RenderControl(hw);
    StringReader sr = new StringReader(sw.ToString());
    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    pdfDoc.Open();
    htmlparser.Parse(sr);
    pdfDoc.Close();
    Response.Write(pdfDoc);
    Response.End(); 
