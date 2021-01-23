    DateTime? gapStart = null ;
    for (int i = 0; i < totaldays; i++)
    {
        if ( gapStart.HasValue )
        {
            if (list[i])
            {
                var whgap  = new WorkHistoryGap();
                whgap.From = gapStart.Value ; //unassigned variable error
                whgap.To   = dtFrom.AddDays(i);
                return whgap;
            }
        }
        else
        {
            gapStart = dtFrom.AddDays(i);
        }
    }
