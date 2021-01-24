    private DateTime _desiredBookingDate = DateTime.Now.Date;  
    public DesiredBookDate 
    {
        get => _desiredBookingDate;
        set => SetProperty(ref _desiredBookingDate, value);
    }  
