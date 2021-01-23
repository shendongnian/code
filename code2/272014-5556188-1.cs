    currentPage.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0} {1}.vcf", this.FirstName, this.LastName));
    currentPage.Response.ContentType = "text/x-vcard";
    currentPage.Response.ContentEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1"); // THIS LINE
    currentPage.Response.Write(content);
    currentPage.Response.End();
  
