    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form2 : Form
        {
            //Fields
            List<string> itemTexts;
    
            public Form2(List<string> itemTexts)
            {
                InitializeComponent();
    
                this.itemTexts = itemTexts;
    
                foreach (string text in itemTexts)
                {
                    textBox1.Text += text + Environment.NewLine;
                }
            }    
        }
    }
