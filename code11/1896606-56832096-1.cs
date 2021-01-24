    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Drawing.Imaging;
    
    namespace stkover
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                tiff2png(@"C:\Users\becsis\Desktop\download.tiff", @"C:\Users\becsis\Desktop\output.png");
            }
    
            private void tiff2png(string imagepath, string outputpath)
            {
                //using System.Drawing;
                //using System.Drawing.Imaging;
                using (var tiff = new Bitmap(imagepath))
                {
                    tiff.Save(outputpath, ImageFormat.Png);
                }
            }
        }
    }
