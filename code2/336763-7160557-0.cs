    progressBar1.Maximum = 50;
    for (int i = 0; i < 50; i++)
    {
        progressBar1.Value++;
        Application.DoEvents();
    }
    MessageBox.Show("Finished");
    progressBar1.Value = 0;
