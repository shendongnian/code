    private void myTabControl_Selecting(object sender, TabControlCancelEventArgs e)
    {
        if (e.Action == TabControlAction.Selecting && e.TabPageIndex == 2)
        {   // the third page is being selected
            var result = MessageBox.Show(
                    "Change to tab?",
                    "Change?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
                e.Cancel = true;
        }
    }
