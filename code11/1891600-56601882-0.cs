        [HttpGet]
        [Route("api/User")]
        public IHttpActionResult GetEmployeeHierarchyList()
        {
          // ...
          return Json(results);
        }
