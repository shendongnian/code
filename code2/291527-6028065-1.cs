     private static void mainForm_FormClosing(object sender, FormClosingEventArgs e)
            {
     UpdatingForm pbar = new UpdatingForm ();
    
    
                pbar.Show();
    while (! pbar.IsDisposed)
    {
    Application.DoEvents()
    }
    }
