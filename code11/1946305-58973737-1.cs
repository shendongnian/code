    int numeroSemana = ObterNumeroSemana(Convert.ToDateTime(visita["dataPrevistaVisita"].ToString()));
    public static int ObterNumeroSemana(DateTime dataVisita)
    {
      CultureInfo ciCurr = CultureInfo.CurrentCulture;
      int weekNum = ciCurr.Calendar.GetWeekOfYear(dataVisita, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
      return weekNum;
    }
