    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing.Imaging;
    
    namespace gray
    {
        public partial class Example : Form
        {
            public Example()
            {
                InitializeComponent();
            }
    
            public static Bitmap getGrayscale(Bitmap hc)
            {
                Bitmap result = new Bitmap(hc.Width, hc.Height);
                ColorMatrix colorMatrix = new ColorMatrix(new float[][]{   
                new float[]{0.5f,0.5f,0.5f,0,0}, new float[]{0.5f,0.5f,0.5f,0,0},
                new float[]{0.5f,0.5f,0.5f,0,0}, new float[]{0,0,0,1,0,0},
                new float[]{0,0,0,0,1,0}, new float[]{0,0,0,0,0,1}});
    
                using (Graphics g = Graphics.FromImage(result))
                {
                    ImageAttributes attributes = new ImageAttributes();
                    attributes.SetColorMatrix(colorMatrix);
                    g.DrawImage(hc, new Rectangle(0, 0, hc.Width, hc.Height),
                       0, 0, hc.Width, hc.Height, GraphicsUnit.Pixel, attributes);
                }
                return result;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                OpenFileDialog fDialog = new OpenFileDialog();
                fDialog.Title = "Open Image File";
                fDialog.Filter = "PNG Files|*.png|Bitmap Files|*.bmp";
                fDialog.InitialDirectory = @"C:\";
    
                if (fDialog.ShowDialog() == DialogResult.OK)
                    this.pictureBox1.ImageLocation = fDialog.FileName.ToString();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                if (this.pictureBox1.Image == null)
                {
                    MessageBox.Show("Sorry no image to alter.");
                    return;
                }
                this.pictureBox1.Image = getGrayscale((Bitmap)this.pictureBox1.Image);
            }
        }
    }
