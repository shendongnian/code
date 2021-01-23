    IEnumerable<StopListMatchViewModel> res =
        from rqResult in MatchesList
        select new StopListMatchViewModel
        {
            MatchDate = DateTime.ParseExact(
                ((rqResult.Row["MatchDate"]==null) ?
                    rqResult.Row["MatchDate"] : DateTime.MinValue).ToString(), "dd.MM.yyyy HH:m:ss", fmtInfo),
            Remark = rqResult.Row["Remark"].ToString()
        }
