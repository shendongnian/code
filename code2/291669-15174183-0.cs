    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SimplePsd;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Media;
    using System.DirectoryServices;
    using System.Diagnostics;
    namespace Master_Graphics
    {
        public partial class Form1 : Form
        { 
            
            private SimplePsd.CPSD psd = new SimplePsd.CPSD();
            Process ffmpeg;
            string video;
            string thumb;
            public Form1()
            {
                InitializeComponent();
            }
     private void button4_Click(object sender, EventArgs e)
            {
    ffmpeg = new Process();
                    ffmpeg.StartInfo.Arguments = "convert \"" + listBox1.SelectedItem.ToString() + "\" -background white -flatten -density 300 -colors 512 -antialias  -normalize -units PixelsPerInch -quality 100 -colorspace RGB -resize 3425x3425  \"D:\\GRAPHICS SEARCH ENGINE\\GRAPHICS IMAGES\\EPS\\" + final + ".jpg\"";
                    ffmpeg.StartInfo.FileName = ("C:\\Program Files (x86)\\ImageMagick-6.5.3-Q16\\convert.exe");
                    ffmpeg.Start();
    }
