        void AddButtons()
        {
            // many things
        }
        void OnButtonClicked()
        {
            MessageBox.Show( "Button clicked!" );
        }
        void OnTabChanged()
        {
            if ( this.Tabs.SelectedIndex == 1 ) {
                this.AddButtons();
            }
        }
