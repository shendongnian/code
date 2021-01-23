    public override void OnTextChanged(TextChangedEventArgs e)
    {
       base.OnTextChanged(e);
       // if we're already cancelling a search, there's nothing more to do until
       // the cancellation is complete.
       if (Worker.CancellationPending)
       {
          return;
       }
       // if there's a search in progress, cancel it.
       if (Worker.IsBusy)
       {
          Worker.CancelAsync();
          return;
       }
       // there's no search in progress, so begin one using the current value
       // of the Text property.
       Worker.RunWorkerAsync(Text);
    }
