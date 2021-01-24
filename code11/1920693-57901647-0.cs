        [HttpPost]
        [ActionName("Tank")]
        public ActionResult Tank(OrderListOfClass ttt, string sendBatch)
        {
            //calling stored procedure 2
            return View("Index", ttt);
        }
