    public class MyApplicationModel:Controller
    {
    
        //use entity framework
        private MyApplicationEntities entities = new MyApplicationEntities();
    
        //
        // Method to query database for price lists table
        public IQueryable<pricingUploaded> GetPricingList()
        {
            return entities.pricingUploadeds;
        }  
    
        // 
        // Method to query Column1 and Column2 in table pricingUploaded
        [HttpGet]
        public ActionResult Query()
        {
           //this action will render the page the first time
           return View();
        }
        [HttpPost]//this method will only accept posted requests
        public ActionResult Query(int column1, int column2) 
        {
             //do something here.
             var _result = entities.Where(x=>x.column1 == column1 && x.column2 == column2);
             return View(_result);//pass result to strongly typed view
        }
