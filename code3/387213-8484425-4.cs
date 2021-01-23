    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (GlobalVariables.FormsList.Count == 1)
        {
            Application.Exit();
        }
        else
        {
            GlobalVariables.FormsList.RemoveAt(GlobalVariables.FormsList.Count - 1);
        }
    }
