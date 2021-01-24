    public class tableData
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string E { get; set; }
    }
And changed controller to this
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Index(List<tableData> tableDatas)
        {
            List<string> total = new List<string>();
            
            for(int i = 0; i < tableDatas.Count(); i++)
            {
                total.Add($"&num_operacion{i+1}={tableDatas[i].A}&monto{i+1}={tableDatas[i].E}&num_documento{i + 1}={tableDatas[i].B}&tipo_documento{i + 1}={tableDatas[i].C}");
            }
            return Json(total);
        }
