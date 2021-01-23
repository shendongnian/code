    ..............
    sh.Buffer = _streamreader.ReadLine();
    .........
    private void backgroundWorker1_ProgressChanged(object _sender, System.ComponentModel.ProgressChangedEventArgs _e)
        {
              
            richTextBox1.Text += "\n" + _e.UserState;
        }
