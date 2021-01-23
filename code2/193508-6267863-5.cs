    int iTake = 40000;
    int iSkip = 0;
    int iLoop;
    ent.CommandTimeout = 6000;
    while (true)
    {
      iLoop = 0;
      IQueryable<viewClaimsBInfo> iInfo = (from q in ent.viewClaimsBInfo
                                           where q.WorkDate >= dtStart &&
                                             q.WorkDate <= dtEnd
                                           orderby q.WorkDate
                                           select q)
                                          .Skip(iSkip).Take(iTake);
      foreach (viewClaimsBInfo qInfo in iInfo)
      {
        iLoop++;
        if (lstClerk.Contains(qInfo.Clerk.Substring(0, 3)))
        {
              /// Various processing....
        }
      }
      if (iLoop < iTake)
        break;
      iSkip += iTake;
    }
