    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ImageHandler : IHttpHandler
    {
    
        public void ProcessRequest(HttpContext context)
        {
            string imageName = string.Empty;
            string physicalPath = string.Empty;
            Image image = null;
            Image thumbnailImage = null;
            Bitmap bitmap = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                string actionName = context.Request.QueryString["Image"];
                string opacity = context.Request.QueryString["Opacity"];
                int opacityPercent = int.Parse(opacity);
                Color waterMarkColor = Color.Gray;
                switch (actionName)
                {
                    case "BlueHills":
                        string myCompany = "My Company Name";
                        Font font = new Font("Times New Roman", 8f);
    
                        context.Response.ContentType = "image/png";
                        bitmap = Resources.Resources.BlueHills;
                        Graphics g = Graphics.FromImage(bitmap);
                        Brush myBrush = new SolidBrush(Color.FromArgb(opacityPercent, waterMarkColor));
                        SizeF sz = g.MeasureString(myCompany, font);
                        int X = (int)(bitmap.Width - sz.Width) / 2;
                        int Y = (int)(sz.Height) / 2;
                        g.DrawString(myCompany, font, myBrush, new Point(X, Y));
                        bitmap.Save(memoryStream, ImageFormat.Png);
                        break;
                    default:
                        string test = actionName;
                        break;
                }
    
                context.Response.BinaryWrite(memoryStream.GetBuffer());
                memoryStream.Close();
                if (image != null) { image.Dispose(); }
                if (thumbnailImage != null) { thumbnailImage.Dispose(); }
                if (bitmap != null) { bitmap.Dispose(); }
            }
        }
    
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
