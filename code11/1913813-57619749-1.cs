    public List<Participant> All_Participants { get; set; }
    public Participants() {
      All_Participants = new List<Participant>();
    }
    private int TotalColumns {
      get {
        int tot = 0;
        foreach (Participant participant in All_Participants) {
          if (participant.LapTimes.Count > tot)
            tot = participant.LapTimes.Count;
        }
        return tot;
      }
    }
    public DataTable GetParticipantDataTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("ID", typeof(string));
      dt.Columns.Add("FirstName", typeof(string));
      dt.Columns.Add("LastName", typeof(string));
      int totColumns = this.TotalColumns;
      for (int i = 1; i <= totColumns; i++) {
        dt.Columns.Add("Lap_" + i, typeof(TimeSpan));
      }
      foreach (Participant participant in All_Participants) {
        DataRow dr = dt.NewRow();
        dr["ID"] = participant.ID;
        dr["FirstName"] = participant.FirstName;
        dr["LastName"] = participant.LastName;
        int curLapCol = 1;
        foreach (TimeSpan span in participant.LapTimes) {
          dr["Lap_" + curLapCol] = span;
          curLapCol++;
        }
        dt.Rows.Add(dr);
      }
      return dt;
    }
