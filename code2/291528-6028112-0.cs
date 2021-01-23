    private bool isClosing = false;
    private static void mainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!isClosing)
        {
            isClosing = true;
            e.Cancel = true;
            UpdatingForm pbar = new UpdatingForm ();
            pbar.Show();
        }
    }   
