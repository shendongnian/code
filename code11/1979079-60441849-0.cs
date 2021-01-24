    public string HistoryTime { get { return SelectedHistoryTime.AddDays(-2).ToShortDate(); } }
    public string Timeframe { 
          get 
          {
             return $"Time Frame: [{SelectedHistoryTime.AddDays(-14)}, {SelectedHistoryTime.AddDays(+14).ToShortDate()}]"; 
          }
     }
