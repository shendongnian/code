      public class Form1
      {
        
          private Bitmap objDrawingSurface;        
          private Rectangle rectBounds1;
        
          private void Button1_Click(object sender, System.EventArgs e) 
          {
             objDrawingSurface = new Bitmap(this.Width, this.Height, Imaging.PixelFormat.Format24bppRgb);
             rectBounds1 = new Rectangle(0, 0, this.Width, this.Height);
             this.DrawToBitmap(objDrawingSurface, rectBounds1);
             SaveFileDialog sfd = new SaveFileDialog();
             sfd.Filter = "JPG Files (*.JPG) |*.JPG";
            if ((sfd.ShowDialog == Windows.Forms.DialogResult.OK))
            {
                objDrawingSurface.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
         }
      }
