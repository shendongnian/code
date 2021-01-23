    if(!IsPostBack)
    {
      foreach (LogisticsTourEntity tour in tourCollection)
        {
            cblRounds.Items.Add(new ListItem(tour.Name, tour.SeqLogisticsTour.ToString()));
        }
    }
