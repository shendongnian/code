    ConsumptionOfRange(List someList, Enum somePeriod)
    {
      foreach (var user in someList.groupBy(d=>d.Name)
      {
          MethodToFillGapsInRange(ref someList)
          
          foreach (var period in someList.GroupBy(d => d.Date.Date))
          {
             // Kind of magic here. Ticks is the "weight" of the period somePeriod.
             // This make query know where in future to look for next valid value.
             var localValues = 
                     (from mv in someList
                      where mv.Date == period.Key 
                      || mv.Date.Date == period.Key.AddTicks(Method(somePeriod).Ticks)
                         select mv).ToList();
     
             // At this place, call the generic function used to calculate range.
             result.Add(ConsumptionRange(dc));
          }
      }   
    }
    
    //That generic function looks like this.
    //Called directly calculating differences between big ranges (1000 or a million of records)
    public AClass ConsumptionOfRange(List someValues)
    {
       AClass grouped = 
            (from d in someValues.OrderBy(d=>d.Date)
             group d by d.Name into gr
             select new VC
             {
                Name = gr.FirstOrDefault().Name,
                Date = gr.FirstOrDefault().Date,
                Value =
                  (gr.LastOrDefault().Value
                    - gr.FirstOrDefault().Value)
                   }).FirstOrDefault();
        return grouped;
    }
