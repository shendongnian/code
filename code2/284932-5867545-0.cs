    public RelayCommand<int> ItemClicked
    {
        get
        {
            return new RelayCommand<int>((i) =>
            {
                MessageBox.Show("Something is clicked - Parameter value is " + i);
            });
        }
    }
