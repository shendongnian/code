    using System.Drawing;
    using System.Windows.Forms;
    namespace yourNameSpaceHere
    {
        public class PopUpBox
        {
            private static Form prompt { get; set; }
        
            public static string GetUserInput(string instructions, string caption)
            {
                string sUserInput = "";
                prompt = new Form() //create a new form at run time
                {
                    Width = 500, Height = 150, FormBorderStyle = FormBorderStyle.FixedDialog, Text = caption,
                    StartPosition = FormStartPosition.CenterScreen, TopMost = true
                };
                //create a label for the form which will have instructions for user input
                Label lblTitle = new Label() { Left = 50, Top = 20, Text = instructions, Dock = DockStyle.Top, TextAlign = ContentAlignment.TopCenter };
                TextBox txtTextInput = new TextBox() { Left = 50, Top = 50, Width = 400 };
                ////////////////////////////OK button
                Button btnOK = new Button() { Text = "OK", Left = 250, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                btnOK.Click += (sender, e) => 
                {
                    sUserInput = txtTextInput.Text;
                    prompt.Close();
                };
                prompt.Controls.Add(txtTextInput);
                prompt.Controls.Add(btnOK);
                prompt.Controls.Add(lblTitle);
                prompt.AcceptButton = btnOK;
                ///////////////////////////////////////
            
                //////////////////////////Cancel button
                Button btnCancel = new Button() { Text = "Cancel", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.Cancel };
                btnCancel.Click += (sender, e) => 
                {
                    sUserInput = "cancel";
                    prompt.Close();
                };
                prompt.Controls.Add(btnCancel);
                prompt.CancelButton = btnCancel;
                ///////////////////////////////////////
                prompt.ShowDialog();
                return sUserInput;
            }
            public void Dispose()
            {prompt.Dispose();}
        }
    }
