    if (includeRegional)
    {
        this[State.Bavaria].AddRange(new HolidayFunc[]
        {
            new HolidayFunc(HolidayCalculator.GetAssumptionDay).AsRegional, 
            new HolidayFunc(HolidayCalculator.GetPeaceFestival).AsRegional
        });
    }
