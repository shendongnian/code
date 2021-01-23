    // delegate
    delegate void ChangeViewStateDelegate ();
    
    // on double click event invoke the custom method
    private void onMouseDoubleClickOnListBoxItem (object sender, MouseButtonEventArgs e) {
        ChangeViewStateDelegate handler = new ChangeViewStateDelegate (Update);
        handler.BeginInvoke (null, null);
    }
    
    // in the custom method invoke the selectall function on the main window (UI which created the listbox) thread
    private void Update () {
        ChangeViewStateDelegate handler = new ChangeViewStateDelegate (UIUpdate);
        this.Dispatcher.BeginInvoke (handler, null);
    }
    
    // call listbox.SelectAll
    private void UIUpdate () {
        lstBox.SelectAll ();
    }
