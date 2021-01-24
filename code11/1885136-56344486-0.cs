    public class SampleViewModel
    {
        public DateTime Date1 {get;set;}        
        public DateTime? Date2 {get;set;}
        public int Diff {get;set;}      
    }
    public ActionResult Index()
    {
        var today = DateTime.Now;
        SampleViewModel model = new SampleViewModel();
        model.Date1=today;
        model.Date2 = today.AddDays(5);
        model.Diff = (int)(model.Date1 - (model.Date2 ?? today)).TotalDays;
        return View(model);
    }
