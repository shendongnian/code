    private void ProcessFilesThree()
    {
       // Assuming you have a textbox control named testTestBox
       // and you wanted to update it on each loop iteration
       // with someMessage
       string someMessage = String.Empty;
            
       for (int i = 0; i < 10; i++)
       {
          Thread.Sleep(1000); //Simulate a second of work.
          someMessage = String.Format("On loop iteration {0}", i);
          testTextBox.Dispatcher.BeginInvoke(new Action<string>((message) =>
          {
              testTextBox.Text = message;
          }), someMessage);
       }
    }
