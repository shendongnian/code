    <%@ WebHandler Language="C#" Class="Handler" %>
    
    using System;
    using System.Web;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    
    public class Handler : IHttpHandler {
        
        public void ProcessRequest (HttpContext context) {
            context.Response.ContentType = "image/jpeg";
            int x = int.Parse(context.Request["x"]);
            int y = int.Parse(context.Request["y"]);
            int h = int.Parse(context.Request["h"]);
            int w = int.Parse(context.Request["w"]);
            int scalew = int.Parse(context.Request["scalew"]);
            int scaleh = int.Parse(context.Request["scaleh"]);
            using (Image img = CustomCrop(w, h, x, y, scalew, scaleh))
                img.Save(context.Response.OutputStream,ImageFormat.Jpeg); 
        }
    
        public static Image CustomCrop(int width, int height, int x, int y, int scalwidth, int scalheight)
        {
            try
            {
                Image image = Image.FromFile("c:\\x.jpg");
                Bitmap bmp = new Bitmap(scalwidth, scalheight, PixelFormat.Format24bppRgb);
                bmp.SetResolution(80, 60);
    
                Graphics gfx = Graphics.FromImage(bmp);
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gfx.DrawImage(image, new Rectangle(0, 0, scalwidth, scalheight), x, y, width, height, GraphicsUnit.Pixel);
    
    
                return bmp;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return null;
            }
        }
        public bool IsReusable {
            get {
                return false;
            }
        }
    
    }
