        string fielName = Server.MapPath("~/file.aspx");
            //File.Create(fielName);
            //File.AppendText(fielName);
    
    
            // create a writer and open the file
            TextWriter tw = new StreamWriter(fielName);
    
            // write a line of text to the file
            tw.WriteLine(@"<%@ Page Language=""C#"" AutoEventWireup=""true""  CodeFile=""file.aspx.cs"" Inherits=""file"" %>
    
    <!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
    
    <html xmlns=""http://www.w3.org/1999/xhtml"">
    <head runat=""server"">
        <title></title>
    </head>
    <body>
        <form id=""form1"" runat=""server"">
        <div>
        
        </div>
        </form>
    </body>
    </html>
    ");
    
            // close the stream
            tw.Close();
    
    
            tw = new StreamWriter(fielName + ".cs");
    
            // write a line of text to the file
            tw.WriteLine(@"using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.IO;
    
    public partial class file : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           Response.Write(""new File "");
    
        }
    }
    ");
    
            // close the stream
            tw.Close();
