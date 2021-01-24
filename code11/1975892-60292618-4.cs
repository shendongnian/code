    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    public delegate void SetTextToForm2(string str);
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            Form2 form2 = new Form2();
    
            public SetTextToForm2 setTextToForm2 { get; set; }
    
            public Form1()
            {
                InitializeComponent();
    
                setTextToForm2 = form2.SetTextFromForm1;
            }
    
            private void TextBox1_TextChanged(object sender, EventArgs e)
            {
                setTextToForm2(textBox1.Text);
            }
    
            private void Button1_Click(object sender, EventArgs e)
            {
                form2.Visible = !form2.Visible;
            }
        }
    }
