    public CalendarData_Day(DateTime datum, DayType typDne)
        : this(datum, typDne,
               typeDne != DayType.Weekend && typeDne != DayType.Holiday)
    {        
    }
    public CalendarData_Day(DateTime datum, DayType typDne, bool vybran)
    {
        if (vybran && (typeDne == DayType.Weekend || typeDne == DayType.Holiday))
        {
            throw new ArgumentException(
               "vybran cannot be true for holiday or weekend dates", "vybran");
        }
        this.Date = datum;
        this.TypeOfDay = typDne;
        this.Choose = vybran;
    }
