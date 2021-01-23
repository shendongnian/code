    //Internally the code looks more like this:
    public ICollection<RSVP> get_RSVPs()
    {
        return _RSVPs;
    }
    
    public void set_RSVPs(RSVP value)
    {
        _RSVPs = value;
    }
    
    private RSVP _RSVPs;
