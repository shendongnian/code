    private void btnOK_Click(object sender, RoutedEventArgs e)
    {
     
    }
     
    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
     
    }
     
    Add the public property in the UserControl1.xaml.cs file to share the value of the textbox with the host
    public string UserName
    {
           get { return txtName.Text; }
           set { txtName.Text = value; }
    }
