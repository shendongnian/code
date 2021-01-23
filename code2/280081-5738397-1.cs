     //Create  CallViewModel contains ReasonName & CompanyName
        public class CallViewModel
        {
            public int id { get; set; }
            public string Text{ get; set; }
            public string ReasonName { get; set; }
            public string CompanyName { get; set; }
        }
    public List<CallViewModel> YourMethid()
    {
        using (Entities _entities = new Entities())
        {
            var result = (from s in _entities.Call.Include("Reason").Include("Company")
                          select new CallViewModel
                              {
                                  id = s.id,
                                  Text = s.Text,
                                  CompanyName = s.Company.name,
                                  ReasonName = s.Reason.name
                              }).ToList();
            return result;
        }
    }
