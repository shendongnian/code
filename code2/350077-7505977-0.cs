    try {
      data = sp.Readline();
    }
    catch (TimeoutException errorEvent)
    {
      //Write to console the errorEvent (This operation has timed out)
      //Message to user to pick correct baud
      tbConsole.AppendText(Environment.NewLine);
      tbConsole.AppendText("Incorrect Baud Rate: Please select a new baud rate");
      tbConsole.AppendText(Environment.NewLine);
      tbConsole.AppendText(errorEvent.Message);
      tbConsole.ScrollToEnd();
      //Show baud rate settings dialog
    }
