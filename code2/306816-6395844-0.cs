       Response.Clear()
        Response.AddHeader("content-disposition", atchment;filename=fm_specification.xls")
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As System.IO.StringWriter = New System.IO.StringWriter
        Dim htmlwrite As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(stringWrite)
        GridView1.RenderControl(htmlwrite)
        Response.Write(stringWrite.ToString)
        Response.End()
