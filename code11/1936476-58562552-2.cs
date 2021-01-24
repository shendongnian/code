     [HttpPost]
     public ActionResult Media(int numero) {
         // (...)
         ViewBag.n = numero;
         // (...)
     }
     [HttpPost]
     public ActionResult Test(int n) {
         // Example of how read posted values
         for (var i = 0; i < n; i++) {
             var valueN = Request.Form["n" + i.ToString()];
         }
     }
