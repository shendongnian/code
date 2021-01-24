      public IHttpActionResult GetToddData()
                {
                BLL.todManager tm = new BLL.todManager();
                Models.TodViewModel tvm = new Models.TodViewModel();
    
                tvm.ModelGetTod = tm.Gettods().ToList();
    
                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tvm.ModelGetTod as IEnumerable<string>);
    
                return Ok(tvm.ModelGetTod);
            }
