        var manuf = (from y in dataContext.Moulds
                where y.MID == cBMeasDBMID.SelectedValue.ToString()
                select y.manuf).FirstOrDefault();
    
        lblManufac.Text = manuf.ToString();
    
        var size = (from a in dataContext.Moulds
               where a.MID == cBMeasDBMID.SelectedValue.ToString()
               select a.Size).FirstOrDefault();
    
        lblSize.Text = size.ToString();
    
        var lastmeas = (from c in dataContext.MeasResults
                   where c.MoldID == cBMeasDBMID.SelectedValue.ToString()
                   select c.Date).FirstOrDefault();
    
        lblLastMeasDate.Text = lastmeas.ToString();
    
        var wi = (from d in dataContext.Moulds
                 where d.MID == cBMeasDBMID.SelectedValue.ToString()
                 select d.AWI).FirstOrDefault();
    
        lblWi.Text = wi.ToString();
