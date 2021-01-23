    private bool isMessageBoxOpen = false;
    public void offlineSetTurn()
    {
        if (isMessageBoxOpen)
            return;
        try
        {
            using (StreamWriter sWriter = new StreamWriter("FileLocation"))
            {
                sWriter.WriteLine(Variable);
            }
        }
        catch (Exception ex)
        {
            isMessageBoxOpen = true;
            DialogResult result = MessageBox.Show("Can't find file.  Click Okay to try again and Cancel to kill program",MessageBoxButtons.OKCancel);
            isMessageBoxOpen = false;
            if (result == DialogResult.OK)
            {
                offlineSetTurn();
            }
            else if (result == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }
    }
