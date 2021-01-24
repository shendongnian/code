    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                txtBoxAdd.Lines = new[] { "Line 1", "Line 2", "Line 3 contains the buzzword", "Line 4", "Line 5 has the buzzword too", "Line 6" };
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                InsertLineAfterBuzzword(buzzword: "buzzword", lineToAdd: "line to add");
            }
    
            private void InsertLineAfterBuzzword(string buzzword, string lineToAdd)
            {
                txtBoxAdd.Lines = txtBoxAdd.Lines
                                           .SelectMany(i => i.Contains(buzzword) ? new[] { i, lineToAdd } : new[] { i })
                                           .ToArray();
            }
        }
    }
