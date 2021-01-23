    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using CorelDRAW;
    
    namespace WebApplication1
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Button1_Click(object sender, EventArgs e)
            {
                CorelDRAW.Application cdr =
                    new Application();
    
                cdr.OpenDocument(@"C:\Users\user\Desktop\500074.cdr", 1);
                cdr.ActiveDocument.ExportBitmap(
                    @"C:\Users\user\Desktop\newImage.png",
                    CorelDRAW.cdrFilter.cdrPNG,
                    CorelDRAW.cdrExportRange.cdrCurrentPage,
                    CorelDRAW.cdrImageType.cdrRGBColorImage,
                    0, 0, 72, 72,
                    CorelDRAW.cdrAntiAliasingType.cdrNoAntiAliasing,
                    false,
                    true,
                    true,
                    false,
                    CorelDRAW.cdrCompressionType.cdrCompressionNone,
                    null).Finish();
                cdr.ActiveDocument.Close();
                cdr.Quit();
            }
    
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
        }
    }
