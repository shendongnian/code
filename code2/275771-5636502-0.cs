     private DelegateCommand<DataRowView> _writeCommand ;
     public ICommand WriteCommand
        {
            get
            {
                return this._writeCommand ??
                       (this._writeCommand = new DelegateCommand<DataRowView>(this.WriteCommandExecute, this.CanWriteCommandExecute));
            }
        }
     private bool CanEditDataCommandExecute(DataRowView rowToWrite)
        {
            return rowToWrite!= null && (bool)rowToWrite["Post"];//if post is a bool
        }
      private void EditDataCommandExecute(DataRowView rowToWrite)
        {
            if (!this.CanEditDataCommandExecute(rowToWrite))
                return;
            //do your stuff here
        }
      
