    private void button1_Click(object sender, EventArgs e)
            {
                bool IsOpen = false;
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Text == "Form1")
                    {
                        IsOpen = true;
                        f.Focus();
                        break;
                    }
                }
     
                if (IsOpen == false)
                {
                    Form f1 = new Form1();
                    f1.Show();
     
                }
            }
