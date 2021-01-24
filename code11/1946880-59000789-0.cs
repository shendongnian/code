     public class ObjectsModel : PageModel
    {
        public class Object
        {
            public string COLUMN1 { get; set; }
            public string COLUMN2 { get; set; }
            public string COLUMN3 { get; set; }
    		public List<ObjectsModel> objects = new <ObjectsModel>();
        }
    
        public void OnGet()
        {
            
        }
    
        public void OnPostGetData(string search)
        {    
            DataAccessLayer.GetData(search, out objects);
            return;
        }
    }
