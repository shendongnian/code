<pre>
public void brightnesstrackBar1_ValueChanged(object sender, EventArgs e) {
        domainUpDownB.Text = ((int)brightnessTrackBar.Value).ToString();
        B = ((int)brightnessTrackBar.Value);
// TODO: Need to dispose of return value from AdjustBrightness somehow
// I need more code to figure out where
        pictureBox2.Image = AdjustBrightness(foto, B);
        foto1 = (Bitmap)pictureBox2.Image;
    }
// Note: Returns a Bitmap that must be Disposed
public static Bitmap AdjustBrightness(Bitmap Image, int Value) {
	int width, height;
	float FinalValue = (float)Value / 255.0f;
        using (Bitmap TempBitmap = Image) {
        	width = TempBitmap.Width;
		height = TempBitmap.Height;
        }
	Bitmap NewBitmap  = new System.Drawing.Bitmap(width, height);
	using (Graphics NewGraphics = Graphics.FromImage(NewBitmap)) {
        	float[][] FloatColorMatrix ={
                                        new float[] {1, 0, 0, 0, 0},
                                        new float[] {0, 1, 0, 0, 0},
                                        new float[] {0, 0, 1, 0, 0},
                                        new float[] {0, 0, 0, 1, 0},
                                        new float[] {FinalValue, FinalValue, FinalValue, 1, 1}
            	};	
        	ColorMatrix NewColorMatrix = new ColorMatrix(FloatColorMatrix);
        	using (ImageAttributes Attributes = new ImageAttributes()) {
        		Attributes.SetColorMatrix(NewColorMatrix);
        		NewGraphics.DrawImage(TempBitmap, new System.Drawing.Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height), 0, 0, TempBitmap.Width, TempBitmap.Height, System.Drawing.GraphicsUnit.Pixel, Attributes);
        	} 
	} 
	return NewBitmap;
}
