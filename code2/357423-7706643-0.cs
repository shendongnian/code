    protected void Page_Load(object sender, EventArgs e)
        {
            string strFile = DateTime.Now.ToString("dd_MMM_yymmss") + ".jpg";
          FileStream log = new FileStream(Server.MapPath(strFile),
           FileMode.OpenOrCreate);
            byte[] buffer = new byte[1024];
            int c;
            while ((c = Request.InputStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                log.Write(buffer, 0, c);
            }
           //Write jpg filename to be picked up by regex and displayed on flash html page.
            Response.Write(strFile);
            log.Close();
    
        }
