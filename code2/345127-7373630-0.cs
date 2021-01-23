    private void DeleteMyData<T>(T value, Action<T> deleteAction)
    {
        this.ModalDialogWorker.ShowDialog<T>(
            this.ModalDialog, this.CustomControl, value, p =>
            {
                if ( this.ModalDialog.DialogResult.HasValue &&
                    this.ModalDialog.DialogResult.Value )
                {
                    deleteAction( p );
                    this._myModel.SaveChangesAsync();
                }
            } );
    }
