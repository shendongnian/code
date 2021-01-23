    using System;
    using System.Windows.Forms;
    namespace ValidateSimple
    {
      using System.Text.RegularExpressions;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void ValidateButton_Click(object sender, EventArgs e)
        {
            string strRegex = @"^(S\d{7}[a-zA-Z])$";
            Regex myRegex = new Regex(strRegex);
            string strTargetString = textBox1.Text;
            if (myRegex.IsMatch(strTargetString))
            {
                MessageBox.Show(@"The NRIC is correct!");
            }
            else
            {
                MessageBox.Show(@"The NRIC is incorrect!");
            }
        }
      }
    }
