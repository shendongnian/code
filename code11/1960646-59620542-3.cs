    void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 2)
            {
                (BindingContext as SampleDetailsViewModel).MySIteSearchResults(e.NewTextValue);
                this.ForceLayout();// force the change in heightrequest for ListView
                MySIteList.IsVisible = true;
                MySIteFrame.IsVisible = true;
            }
            else
            {
                MySIteList.IsVisible = false;
                MySIteFrame.IsVisible = false;
            }
        }
