    private void ViewCell_Tapped(object sender, ItemTappedEventArgs e)
    {
        try
        {
            MessagingCenter.Send(this, "Invoke", "Invokedtrue");
        }
        catch (Exception ex)
        {
            Debug.Write(ex);
        }
    }
   
