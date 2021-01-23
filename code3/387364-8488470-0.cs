    set { 
        points = value; 
        if (Partner != null && Partner.Points != value)
        {
            Partner.Points = value;
        }
    }
