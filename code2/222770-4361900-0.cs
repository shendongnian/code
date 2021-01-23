    <%
      Response.ContentType="text/xml"
    
      Response.Write("<?xml version=""1.0"" encoding=""UTF-8"">");
      Response.Write("<MyFancyRecord>");
      Response.Write("<Title>" + someRec.Title + "</Title>");
      Response.Write("<Price>" + (someRec.Price * 1.20) + "</Price>");
      // etc.
      Response.Write("</MyFancyRecord>");
    
      Response.End();
    %>
