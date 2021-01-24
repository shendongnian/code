        public partial class Form1 : Form
        {
            ...
            private void secondFormButton_Click(object sender, EventArgs e)
            {
                var dlg = new Form2();
                dlg.SetPersonalInformation(this.PersonalInformation);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    // user pressed OK in second form
                }
            }
        }
