    class YourPage : Page
    {
        private void YourMethod()
        {
            try
            {
                // do stuff
            }
            catch(Exception ex)
            {
                this.ShowAlert(ex.Message);
            }
        }
    }
