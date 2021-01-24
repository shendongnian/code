    private void Form1_Load(object sender, EventArgs e)
    {
        #region Disable controls here
        textbox1.Enabled = false;
        button1.Enabled = false;
        combobox1.Enabled = false;
        #endregion
        Task.Factory.StartNew(() => {
            try
            {
                // Do Long running processing of form prerequisites here.
                ...
                // Enable controls here once processing is sucessful and complete.
                Invoke((Action) (() => {
                    textbox1.Enabled = true;
                    button1.Enabled = true;
                    combobox1.Enabled = true;        
                }));
            }
            catch(Exception e)
            {
                Invoke((Action) (() => {
                    MessageBox.Show(e.Message);
                }));
            }    
        });
    }
