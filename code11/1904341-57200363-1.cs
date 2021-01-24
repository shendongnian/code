        void TxtEntry_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            txtEntry.TextChanged -= TxtEntry_TextChanged;
            char key = e.NewTextValue?.Last() ?? ' ';
            if (key == 'A')
            {
                //do something 
            }
            txtEntry.TextChanged += TxtEntry_TextChanged;
        }
