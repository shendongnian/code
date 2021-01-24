    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    namespace Demo
    {
        public partial class Form1 : Form
        {
            private List<Button> _buttons;
            public Form1()
            {
                InitializeComponent();
                _buttons = Controls.OfType<Button>().ToList();
            }
            private void ChangeTextButton_Click(object sender, EventArgs e)
            {
                var result = _buttons.FirstOrDefault(button => button.Text == "button2");
                if (result == null) return;
                result.Text = label1.Text;
           }
        }
    }
