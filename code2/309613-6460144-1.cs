    var vm = (MyViewModel)DataContext;
    vm.CloseRequested += vm_CloseRequested;
    ...
    private void vm_CloseRequested(object sender, CloseRequestedEventArgs e)
    {
        if (e.DialogResult.HasValue)
            this.DialogResult = e.DialogResult; // sets the dialog result AND closes the window
        else
            this.Close();
    }
