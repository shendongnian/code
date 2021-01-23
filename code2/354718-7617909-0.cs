    //in ParentControlViewModel, change your EndDate to:
    public DatePickerViewModel EndDate
    {
      get { return _endDate; }
      set
      {
        _endDate = value;
        if (_endDate.ParentControlViewModel == null)
        {
        _endDate.ParentControlViewModel = this;
        }
        RaisePropertyChanged(() => EndDate);
      }
    }
    
    //Add to DatePickerViewModel
    public ParentControlViewModel ParentControlViewModel { get; set; }
    
    //Change Date property in DatePickerViewModel to:
    public GDate Date
    {
      get { return _date; }
      set
      {
        _date = value;
        RaisePropertyChanged(() => Date);
        if (ParentControlViewModel != null)
        {
          ParentControlViewModel.EndDate = this;
        }
      }
    }
       
