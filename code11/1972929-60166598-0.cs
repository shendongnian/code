    [HttpPost]
        public JsonResult GetConditionOfDisease(string inputString)
        {
            var ds = new DataSet();
            using (var adapter = new OleDbDataAdapter("select * from [history$]", connectionString))
            {               
                adapter.Fill(ds, "CompetitorAsset");
            }
            System.Data.DataTable data = ds.Tables["CompetitorAsset"];
            List<string> conditionOfDisease = data.AsEnumerable().Select(r => r.Field<string>("F5")).ToList();
            conditionOfDisease.RemoveAt(0);
            var distinctConditionOfDisease = conditionOfDisease.Distinct().ToList();
            var matchConditionOfDisease = distinctConditionOfDisease.Where(s => s != null && s.Trim().ToLower().Contains(inputString.Trim().ToLower())).ToList();
            return Json(matchConditionOfDisease);
        }
