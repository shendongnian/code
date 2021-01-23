    private void deleteOperationCompletedM(SubmitOperation op) {
      if (op.Error == null) {
        MessageBox.Show("Delete operation was successfull.");
        // Some other code here (removed for brevity)
      }
      else{
        op.MarkErrorAsHandled();
        MessageBox.Show("An error has occured." + op.Error.Message);
        db.RejectChanges();  // call reject changes on the DomainContext
      }
    }
