protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == 0x0312)
        {
            Task.Run( () => {
              for( int i=0; i<1300; i++ )
              {
                  var file_name = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff") + ".jpg";
                  using( var bitmap = GetPlayedScreen())
                  {
                    bitmap.Save("D:\\Test\\" + file_name, ImageFormat.Jpeg)
                  }
            // Needs some WinForms dispatch message here...
            //    label1.Text = @"● " + file_name;
              }
            }
        }
    }
    private Bitmap GetPlayedScreen()
    {
        var rect = new Rectangle(Location.X, Location.Y, Width, Height);
        var img = new Bitmap(rect.Width, rect.Height, PixelFormat.Format64bppArgb);
        var GFX = Graphics.FromImage(img);
        GFX.CopyFromScreen(rect.Left, rect.Top, 0, 0, Size);
        return img;
    }
