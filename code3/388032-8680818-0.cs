    float Zoom = 1f;
    Microsoft.Xna.Framework.Rectangle mouseRect;
    Matrix inverse;
    void TAB_PICTURE_BOX_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Delta > 0)
                {
                    Zoom+= .1f;
                }
                if (e.Delta < 0)
                {
                    Zoom -= .1f;
                }
                gfx.ResetTransform();
                gfx.TranslateTransform((Width + img.Width) / 2, (Height - img.Height) / 2);
                gfx.ScaleTransform(Zoom, Zoom);
                gfx.TranslateTransform(-(Width + img.Width) / 2, -(Height - img.Height) / 2);      
                    getInversePosition(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
