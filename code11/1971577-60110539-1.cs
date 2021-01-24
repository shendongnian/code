    public Delivery(DeliveryPeriodEnum deliveryPeriod, IEnumerable<DayOfWeek> days)
    {
           _deliveryPeriod = deliveryPeriod;
           _days = days;
    
            if (_deliveryPeriod == DeliveryPeriodEnum.Nothing && _days?.Any() == true)
                throw new GeneralException("There cannot be days for given period");
    
            if (_deliveryPeriod != DeliveryPeriodEnum.Nothing && (_days?.Any() ?? false) == false)
                throw new GeneralException("Period has to have at least one item in list");
    }
