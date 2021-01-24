     [HttpGet]
     public async Task<ActionResult<IEnumerable<Client>>> GetClient()
      {
         var myData=await _context.Client.ToListAsync();
         return Json(myData , JsonRequestBehavior.AllowGet);
      }
