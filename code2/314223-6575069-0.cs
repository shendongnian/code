    public TimeSpan TimeSpanAverage(TimeSpan earlier, TimeSpan later) {
    	
    	return (new TimeSpan((earlier.Ticks + later.Ticks) / 2));	
    	
    }
