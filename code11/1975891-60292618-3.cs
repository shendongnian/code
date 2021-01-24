    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    public delegate void SetTextToForm1(string str);
    
    namespace WindowsFormsApp1
    {
    
        public partial class Form2 : Form
        {
            public SetTextToForm1 setTextToForm1 { get; set; }
    
            public Form2(SetTextToForm1 SetTextMethod, string strTextFromForm1)
            {
                InitializeComponent();
    
                this.setTextToForm1 = SetTextMethod;
                this.textBox1.Text = strTextFromForm1;
            }
    
            private void TextBox1_TextChanged(object sender, EventArgs e)
            {
                setTextToForm1(textBox1.Text);
            }
        }
    }
