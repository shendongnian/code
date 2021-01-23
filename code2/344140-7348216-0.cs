    private void cmbSubjects_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (pnlAvailable.Controls.Count != 0)
        {
            if (cmbSubjects.SelectedIndex != cmbIndex)
            {
                DialogResult res = MessageBox.Show("There are still available questions. Are you sure you want to change the subject?", "Changing subject...", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (res == DialogResult.Yes)
                {
                    cmbIndex = cmbSubjects.SelectedIndex;
                    switch (cmbSubjects.SelectedIndex)
                    {
                        case 0:
                            subject = "life";
                            break;
                        case 1:
                            subject = "math";
                            break;
                        case 2:
                            subject = "physical";
                            break;
                        case 3:
                            subject = "technology";
                            break;
                        case 4:
                            subject = "vocational";
                            break;
                    }
                    GenQstBtns();
                }
                else if (res == DialogResult.No)
                {
                    cmbSubjects.SelectedIndex = cmbIndex;
                }
            }
        }
    }
