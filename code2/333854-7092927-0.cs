      private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
           //disable button here so no more clicking until processing is done
           //start a backgroundworker that will do the processing
        }
       BackgroundWorker()
       {
           try 
           {
              Cursor = Cursors.Wait;                 
              Processor.UpdateData(); 
           }
           catch (RemoteConnection x)
           {
              ShowConnectionError(this, x);
           }
           finally
           {
              Cursor = Cursors.Arrow;
              //enable button again using Dispatcher
           }
       }
