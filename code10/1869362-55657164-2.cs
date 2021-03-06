    using System;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Open Image";
                    dlg.Filter = "bmp files (*.bmp)|*.bmp";
    
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        var colorCodes = this.GetColorCodes(dlg.FileName);
                        var str = string.Join(Environment.NewLine,
                                              colorCodes.Select(line => string.Join(" ", line.Select(code => $"{code:X8}")))); // $"{code & 0x00FFFFFF:X6}" if you want RRGGBB format
                        textBox1.Text = str; // requires textBox1.Multiline = true, better have monospaced font
                    }
                }
            }
    
            private int[][] GetColorCodes(string path)
            {
                var bitmap = new Bitmap(path);
                return Enumerable.Range(0, bitmap.Height)
                                 .Select(y => Enumerable.Range(0, bitmap.Width)
                                                        .Select(x => bitmap.GetPixel(x, y).ToArgb())
                                                        .ToArray())
                                 .ToArray();
            }
        }
    }
