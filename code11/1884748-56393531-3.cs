     //model class
        public class YourModelItem
        {
            public int Id { get; set; }
            public string YourProperty { get; set; }
        }
   
    
        //controller
        public class HomeController : Controller
        {
            private static List<YourModelItem> _modelItems = new List<YourModelItem>();
    
            public ActionResult Index()
            {
                GridDefinition<YourModelItem> def = new GridDefinition<YourModelItem>();
    
                GridColumn<YourModelItem> column = new GridColumn<YourModelItem>();
                column.ColumnName = "UniqueColumnName";
                column.HeaderText = "Any Header";
                column.ValueExpression = (i, c) => i.YourProperty;
                def.AddColumn(column);
    
                def.RetrieveData = (options) => new QueryResult<YourModelItem>()
                {
                    Items = _modelItems,
                    TotalRecords = 0
                };
    
                MVCGridDefinitionTable.Add("NonFluentUsageExample", def);
    
                return View();
            }
    
            [HttpPost]
            public JsonResult Add(YourModelItem item)
            {
                _modelItems.Add(item);
    
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
