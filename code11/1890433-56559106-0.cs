    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using IronPython;
    using IronPython.Hosting;
    using System.IO;
    
    namespace CSharp_with_Python_Script
    {
        public partial class Form1 : Form
        {
            string nombreTextbox1;
            string nombreTextbox2;
            string chiffre_1;
            string chiffre_2;
    
            public Form1()
            {
                InitializeComponent();
    
    
            }
    
            static void Execute()
            {
    
                chiffre_1 = nombreTextBox1;
                chiffre_2 = nombreTextBox2;
    
                var psi = new ProcessStartInfo();
                psi.FileName = 
    @"C:\Users\adm\AppData\Local\Programs\Python\Python37-32\python.exe";              
    
    
    
                var script = @"C:\Users\adm\Documents\Visual Studio 
    2017\Projects\CSharp_with_Python_Script\Class_Plot\Class_Plot.py";     
                var chiffre_1 = nombreTextBox1;
                var chiffre_2 = nombreTextBox2;
                psi.Arguments = $"\"{script}\" \"{chiffre_1}\" \"{chiffre_2}\"";
    
    
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
    
    
                var errors = "";
                var result = "";
    
                using (var process = Process.Start(psi))
                {
                    errors = process.StandardError.ReadToEnd();
                    result = process.StandardOutput.ReadToEnd();
                }
    
    
    
            }
    
            private void Btn_ChangePicture_Click(object sender, EventArgs e)
            {
                pictureBox1.ImageLocation = (@"C:\Users\adm\Documents\Visual 
    Studio 
    2017\Projects\CSharp_with_Python_Script\Class_Plot\PLOT_MATPLOTLIB.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
    
    
            private void Btn_Script_Click(object sender, EventArgs e)
            {    
                Execute();
            } 
    
            private void button1_Click(object sender, EventArgs e)
            {
                nombreTextbox1 = textBox1.Text;
                nombreTextbox2 = textBox2.Text;
            }
        }
    }
