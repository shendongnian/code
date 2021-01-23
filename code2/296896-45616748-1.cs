	 /*
	Copyright (c) 2010 <a href="http://www.gutgames.com">James Craig</a>
	 Permission is hereby granted, free of charge, to any person obtaining a copy
	 of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:
	The above copyright notice and this permission notice shall be included in
	all copies or substantial portions of the Software.
	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
	THE SOFTWARE.*/
	using System.Drawing;
	using System.Drawing.Imaging;
	namespace WebCamService {
	    class ColorMatrix {
	        public float[][] Matrix { get; set; }
	        public Bitmap Apply(Bitmap OriginalImage) {
	            using (Graphics NewGraphics = Graphics.FromImage(OriginalImage)) {
	                System.Drawing.Imaging.ColorMatrix NewColorMatrix = new System.Drawing.Imaging.ColorMatrix(Matrix);
	                using (ImageAttributes Attributes = new ImageAttributes()) {
	                    Attributes.SetColorMatrix(NewColorMatrix);
	                    NewGraphics.DrawImage(OriginalImage,
	                        new System.Drawing.Rectangle(0, 0, OriginalImage.Width, OriginalImage.Height),
	                        0, 0, OriginalImage.Width, OriginalImage.Height,
	                        GraphicsUnit.Pixel,
	                        Attributes);
	                }
	            }
	            return OriginalImage;
	        }
	        public static Bitmap ConvertBlackAndWhite(Bitmap Image) {
	            ColorMatrix TempMatrix = new ColorMatrix();
	            TempMatrix.Matrix = new float[][]{
	                     new float[] {.3f, .3f, .3f, 0, 0},
	                    new float[] {.59f, .59f, .59f, 0, 0},
	                     new float[] {.11f, .11f, .11f, 0, 0},
	                    new float[] {0, 0, 0, 1, 0},
	                    new float[] {0, 0, 0, 0, 1}
	                };
	            return TempMatrix.Apply(Image);
	        }
	    }
	}
