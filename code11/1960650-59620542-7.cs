    void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
                        if (e.NewTextValue.Length > 2)
            {
                (BindingContext as SampleDetailsViewModel).MySIteSearchResults(e.NewTextValue);
                this.ForceLayout();// force the change in heightrequest for ListView
                MyObjectList.IsVisible = true;
                MyObjectFrame.IsVisible = true;
            }
            else
            {
                MyObjectList.IsVisible = false;
                MyObjectFrame.IsVisible = false;
            }
        }
