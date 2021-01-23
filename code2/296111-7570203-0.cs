    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.IO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            var reader = new PdfReader(Server.MapPath("~/Emptyform.pdf"));
            var output = new MemoryStream();
            var stamper = new PdfStamper(reader, output);
            stamper.AcroFields.SetField("TextField1", TextBox1.text);
            stamper.FormFlattening = true;
            stamper.Close();
            reader.Close();
            File.WriteAllBytes(Server.MapPath("~/Filledform.pdf"),output.ToArray());        
        }
    }
