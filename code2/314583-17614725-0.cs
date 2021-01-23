    private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        string text = null;
        myTextBox.Dispatcher.Invoke(new Action(delegate()
        {
            text = myTextBox.Text;
        }));
    }
