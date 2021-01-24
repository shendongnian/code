    public int SelectedIndexDoor
    {
        get { return selectedIndexDoor; }
        set
        {
            selectedIndexDoor = value;
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                selectedIndexDoor = -1;
                OnPropertyChanged("SelectedIndexDoor");
            }));
        }
    }
