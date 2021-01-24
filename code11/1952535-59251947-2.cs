       public class MarketViewModel
            {
                public List<YourModel> ListForChart { get; set; }
                public List<YourModel> ListForChart2 { get; get;}
        }
    
    example Service from your code:
    public class YourService{
     private List<YourModel> exampleList;
     public YourService(){
      exampleList = new List<YourModel>();
    }
    
     public List<YourModel> GetWeekly(param1, param2)
       // data is List of your model. return this.
       var data = (from a in ExpenseReport
                        join at in Amount on a.ItemName equals at.Amount
                        where a.Date >= FromDate
                              && a.Date < ToDate
                        group at by at.ItemName into g
                        select new
                        {
                            value = g.Count(),
                            label = g.Key
                        }).ToList();
    
    return data;
    
    }
    }
