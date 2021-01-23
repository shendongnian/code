     //File:ImageGen.aspx
        public partial class ImageGen: System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                string id = Request.QueryString["id"];
                Bitmap image = new Bitmap(800, 400);
                //Code to generate image
                image.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
