    private bool executingSelectedIndexChanged  = false;
    private void cmbSubjects_SelectedIndexChanged(object sender, EventArgs e)
    {
        // NEW CODE HERE
        if (executingSelectedIndexChanged)
        {
            executingSelectedIndexChanged = false;
            return;
        }
        if (pnlAvailable.Controls.Count != 0)
        {
            if (countMsg < 1)
            {
                // NEW CODE HERE
                executingSelectedIndexChanged  = true;
                DialogResult res = MessageBox.Show("There are still available questions. Are you sure you want to change the subject?", "Changing subject...", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (res == DialogResult.Yes)
                {
                    // NEW CODE HERE
                    executingSelectedIndexChanged = false;
                    cmbIndex = cmbSubjects.SelectedIndex;
                    countMsg = 0;
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
                    countMsg = 1;
                    cmbSubjects.SelectedIndex = cmbIndex;
                }
            }
        }
    }
