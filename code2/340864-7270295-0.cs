      string style = @"<style> .text { mso-number-format:\@; } </style> ";
      Response.ClearContent();
      Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
      Response.ContentType = "application/excel";
      StringWriter sw = new StringWriter();
      HtmlTextWriter htw = new HtmlTextWriter(sw);
      gvUsers.RenderControl(htw);
      
      // Style is added dynamically
      Response.Write(style);
      Response.Write(sw.ToString());
      Response.End();
