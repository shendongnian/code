    [HttpGet]
    public async Task<ActionResult> GetNodes() {
         var parentId = Request.QueryString["parentId"].ToString();
         Guid guid;
         if (Guid.TryParse(parentId , out guid))
         {
           // use guid here
         }
    }
