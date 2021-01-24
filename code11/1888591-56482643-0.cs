    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace StackoverflowHelp
    {
      public partial class Form1 : Form
      {
        Form2 form = new Form2();
    
        public Form1()
        {
          InitializeComponent();
          form.Show();
        }
    
        private void Button1_Click(object sender, EventArgs e)
        {
          form.DrawCircle(100, 100);
        }
      }
    }
