    private void btnOK_Click(object sender, RoutedEventArgs e)
    {
          if (OkClick != null)
              OkClick(this, e);
    }
     
    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        if (CancelClick != null)
           CancelClick(this, e);
    }
