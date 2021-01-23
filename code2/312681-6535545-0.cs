    protected void Button1_Click(object sender, EventArgs e)
    {
       // ...you calculations here...
        StringBuilder sbRenderOnMe = new StringBuilder();
        // the form and the data
        sbRenderOnMe.AppendFormat(
        "<html><body><form action=\"http://www.google.com\" method=\"post\" name=\"form1\">"
             + "<input value=\"{0}\" id=\"lst-Send1\" name=\"Send1\" type=\"hidden\" />"
             + "<input type=\"submit\" name=\"Button1\" value=\"press me if not automatically redirect\" id=\"Button1\" />"
         + "</form>"
         , 1100
        );
        // the auto submit
        sbRenderOnMe.AppendFormat("<script>document.form1.submit();</script>");       
        sbRenderOnMe.AppendFormat("</body></html>");
        Response.Write(sbRenderOnMe.ToString());
        Response.End();
    }
