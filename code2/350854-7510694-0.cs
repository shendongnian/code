    <%@ Page Language="C#" %>
    <%@ Import Namespace="System" %>
    <%@ Import Namespace="System.Drawing" %>
    <%@ Import Namespace="System.Drawing.Color" %>
    <%@ Import Namespace="System.Drawing.Imaging" %>
    <script language="C#" runat="server">
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Bitmap objBMP = new Bitmap(60, 20);
            Graphics objGraphics = Graphics.FromImage(objBMP);
            objGraphics.Clear(Color.Wheat);
            objGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            //' Configure font to use for text
            Font objFont = new Font("Arial", 8, FontStyle.Italic);
            string randomStr = "";
            char[] myArray = new char[5];
            int x;
            //That is to create the random # and add it to our string
            Random autoRand = new Random();
            for (x = 0; x < 5; x++)
            {
                myArray[x] = System.Convert.ToChar(autoRand.Next(65, 90));
                randomStr += (myArray[x].ToString());
            }
            //This is to add the string to session, to be compared later
            Session.Add("RandomStr", randomStr);
            //' Write out the text
            objGraphics.DrawString(randomStr, objFont, Brushes.Red, 3, 3);
            //' Set the content type and return the image
            Response.ContentType = "image/GIF";
            objBMP.Save(Response.OutputStream, ImageFormat.Gif);
            objFont.Dispose();
            objGraphics.Dispose();
            objBMP.Dispose();
        }
    </script>
