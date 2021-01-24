    public ICommand TappedDateCommand => new Command<string>(ChangeToTappedDate);
    
    private void ChangeToTappedDate(string position)
    {
        Position = Convert.ToInt32(position);
        PositionChanged(position);
        OnPropertyChanged("Position");
    }
