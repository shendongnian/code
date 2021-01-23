    using System;
    using System.Windows.Forms;
    
    namespace SO_Suffix
    {
        public partial class Form1 : Form
        {
            Form2 form2 = new Form2();
            
            public Form1()
            {
                InitializeComponent();
                 //<  subscribe to the custom event from form2 and set which function to delegate it to ( form2_ButtonClicked )			
                form2.ButtonClicked += new Form2.ButtonClickedOnForm2(form2_ButtonClicked);
                form2.Show();
            }
    
            private void form2_ButtonClicked(object sender, EventArgs e)
            {
                this.Controls.Add(new Button());
            }
        }
    }
